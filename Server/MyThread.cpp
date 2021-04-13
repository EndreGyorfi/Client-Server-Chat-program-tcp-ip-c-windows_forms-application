#include <stdio.h>
#include "winsock2.h"
#include "ws2tcpip.h"
#include "SysThread.h"
#include "MyThread.h"
#include<string>
#include<sstream>
#include<iostream>
//#include<map>
using namespace std;


MyThread::MyThread(vector<MyThread*>* arr, CRITICAL_SECTION* krit_szekcio, SOCKET AcceptSocket, string s, int sorsz, string gps) :Threads(arr)
{
    this->groups = gps;
    this->sorszam = sorszam;
    this->strName = s;
    this->CS = krit_szekcio;
    this->MySock = AcceptSocket;
}


bool szerepel(vector<int>& vec, int num) {
    for (auto x : vec) {
        if (x == num) {
            return true;
        }
    }
    return false;
}

bool szerepelStr(vector<string>& vec, string str) {
    for (auto x : vec) {
        if (x == str) {
            return true;
        }
    }
    return false;
}

vector<string> split(string s) {
    string delimiter = "/";
    size_t pos_start = 0, pos_end, delim_len = delimiter.length();
    string token;
    vector<string> res;

    while ((pos_end = s.find(delimiter, pos_start)) != string::npos) {
        token = s.substr(pos_start, pos_end - pos_start);
        pos_start = pos_end + delim_len;
        res.push_back(token);
    }

    res.push_back(s.substr(pos_start));
    return res;
}

string egyszerusit(string s) {
    vector<string>tagok = split(s);
    vector<string>tagokSimple;
    string groups = "";
    for (auto x : tagok) {
        if (!szerepelStr(tagokSimple, x)) {
            tagokSimple.push_back(x);
        }
    }
    for (auto y : tagokSimple) {
        groups.append("/");
        groups.append(y);
    }
    return groups;
}


void MyThread::run(void) {
    int iResult = -1;

    const int BufLen = 1024;


    bool runing = true;

    do {
        printf("Receiving datagrams...\n");

        char RecvBuf[BufLen] = {};

        iResult = recv(MySock, RecvBuf, BufLen, 0);
        if (iResult == SOCKET_ERROR)
        {
            closesocket(MySock);
            runing = false;
        }


        printf("%s \n", RecvBuf);

        // Send a datagram
        //EnterCriticalSection(CS);
        char bu[BufLen] = {};

        int type;
        type = int(RecvBuf[0]) - (int)48;
        int z = 0;
        string felado, cimzett;
        int ii = 2;
        int k = 0;
        int ciklus = 0;
        while (RecvBuf[ii] != '/') {
            felado += RecvBuf[ii];
            ++k;
            ++ii;
            ++z;
            ++ciklus;
            if (ciklus > 1024) {
                break;
            }
        }
        ii += 1;
        k = 0;
        ciklus = 0;
        while (RecvBuf[ii] != '/') {
            cimzett += RecvBuf[ii];
            ++k;
            ++ii;
            ++ciklus;
            if (ciklus > 1024) {
                break;
            }
        }

        ii += 1;
        k = 0;
        ciklus = 0;
        while (RecvBuf[ii]) {
            bu[k] += RecvBuf[ii];
            ++k;
            ++ii;
            ++ciklus;
            if (ciklus > 1024) {
                break;
            }
        }
        ciklus = 0;
        char uzenet[BufLen * 2];
        char CsatlakozasErtesites[BufLen] = "You are joined to group...";
        for (int i = 0; i < z; ++i) {
            uzenet[i] = felado[i];
            ++ciklus;
            if (ciklus > 1024) {
                break;
            }
        }
        uzenet[z] = '<';
        uzenet[z + 1] = '<';
        ciklus = 0;
        int cc = 0;
        for (int i = z + 2; i < BufLen * 2; ++i) {
            uzenet[i] = bu[cc];
            ++cc;
            ++ciklus;
            if (ciklus > 1024) {
                break;
            }
        }


        int cimzettInt = 10, feladoInt = 10;
        stringstream geek1(cimzett);
        stringstream geek2(felado);
        geek1 >> cimzettInt;
        geek2 >> feladoInt;


        if (type == 0) {
            this->strName = cimzett;
            this->sorszam = Threads->size() - 1;
        }
        if (type == 3) {//createGroup
            this->groups = this->groups + "/" + felado + '/';//az elso ertek a csoport neve, aki letrehozza a csoportot automatikusan belekerul
        }
        if (type == 4) {//add member to group
            this->groups = this->groups.append("/" + string(bu) + '/');
        }

        string groupStr = "";
        for (auto& x : *Threads) {
            groupStr = groupStr.append("/" + this->groups);
            // x->groups = groupStr;
        }

        for (auto& x : *Threads) {
            x->groups = egyszerusit(groupStr);
        }

        //cout << "Csoportok: " << groupStr << endl;

        vector<int>cimzettek;
        vector<string>csoporttagok = split(groupStr);

        for (auto& x : *Threads) {
            for (auto y : csoporttagok) {
                if (y == x->strName && !szerepel(cimzettek, x->sorszam)) {
                    cimzettek.push_back(x->sorszam);
                }
            }
        }
       // cout << "A kovetkezo sorszamu embereknek kell kuldeni: ";
        for (auto x : cimzettek) {
            //cout << x << "   ";
        }
       // cout << endl;


        for (auto& x : *Threads) {
            cout << x->strName << "   " << x->sorszam << endl;
            if (cimzett == x->strName) {
                cimzettInt = x->sorszam;
            }
        }

        for (auto& x : *Threads) {
            if (felado == x->strName) {
                feladoInt = x->sorszam;
            }
        }

        char successBuff[BufLen];
        strcpy(successBuff, "You create a group succesfully...");

        int i = 0;
        for (auto& x : *Threads) {
            if (type == 2) {
                if (i == cimzettInt) {
                    iResult = send(x->getSocket(), uzenet, BufLen, 0);
                    if (iResult == SOCKET_ERROR)
                    {
                        printf("Hiba a kuldesnel a kovetkezo hibakoddal: %d\n", WSAGetLastError());
                        closesocket(x->getSocket());
                    }
                }
            }
            if (type == 1) {
                iResult = send(x->getSocket(), uzenet, BufLen, 0);
                if (iResult == SOCKET_ERROR)
                {
                    printf("Hiba a kuldesnel a kovetkezo hibakoddal: %d\n", WSAGetLastError());
                    closesocket(x->getSocket());
                }
            }
            if (type == 3) {
                if (i == feladoInt) {
                    iResult = send(x->getSocket(), successBuff, BufLen, 0);
                    if (iResult == SOCKET_ERROR)
                    {
                        printf("Hiba a kuldesnel a kovetkezo hibakoddal: %d\n", WSAGetLastError());
                        closesocket(x->getSocket());
                    }
                }
            }
            if (type == 5) {
                for (auto cim : cimzettek) {
                    if (i == cim) {
                        iResult = send(x->getSocket(), uzenet, BufLen, 0);
                        if (iResult == SOCKET_ERROR)
                        {
                            printf("Hiba a kuldesnel a kovetkezo hibakoddal: %d\n", WSAGetLastError());
                            closesocket(x->getSocket());
                        }
                    }
                }
            }
            if (type == 4) {
                if (i == cimzettInt) {
                    iResult = send(x->getSocket(), CsatlakozasErtesites, BufLen, 0);
                    if (iResult == SOCKET_ERROR)
                    {
                        printf("Hiba a kuldesnel a kovetkezo hibakoddal: %d\n", WSAGetLastError());
                        closesocket(x->getSocket());
                    }
                }
            }
            if (type == 6) {
                if (i == cimzettInt) {
                    iResult = send(x->getSocket(), RecvBuf, BufLen, 0);
                    if (iResult == SOCKET_ERROR)
                    {
                        printf("Hiba a kuldesnel a kovetkezo hibakoddal: %d\n", WSAGetLastError());
                        closesocket(x->getSocket());
                    }
                }
            }
            ++i;
        }

        //LeaveCriticalSection(CS);

        //Delete clients
        EnterCriticalSection(CS);
        for (int i = 0; i < Threads->size(); ++i) {
            if (Threads->at(i)->isExited() == true) {
                Threads->erase(std::remove(Threads->begin(), Threads->end(), Threads->at(i)), Threads->end());
            }
        }
        LeaveCriticalSection(CS);


    } while (iResult > 0);
}

