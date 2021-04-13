#pragma once
#include<vector>
#include<string>
using namespace std;

class MyThread:public SysThread
{
private:
	vector<MyThread*>* Threads;
	CRITICAL_SECTION* CS;
	SOCKET MySock;
	string strName = "";
	int sorszam = 0;
	string groups = "";
	
public:
	MyThread(vector<MyThread*>* ,CRITICAL_SECTION* ,SOCKET, string, int, string);
	virtual void run();

public:
	SOCKET getSocket() {
		return this->MySock;
	}
};

