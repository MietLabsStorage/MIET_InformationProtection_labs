#include <iostream>
#include <fstream>
#include "task2.h"
#include <map>
#include <bitset>

int task2run() {

    //читаем файл
    std::ifstream in("task2.txt", std::ios::in | std::ios::binary);
    if (!in) {
        std::cout << "Cannot open file.\n";
        return 1;
    }

    //перемещение указателя в конец
    in.seekg(0,std::ios::end);
    //определение текущей позиции указателя
    double size = in.tellg();
    //возвращаем указатель в начало
    in.seekg(0,std::ios::beg);

    //считаем частоту
    std::map<char , int> bytesFreq;
    char ch;
    while (in.read(&ch, 1)) {  
        if(bytesFreq.count(ch)){
            bytesFreq[ch] += 1;
        }
        else{
            bytesFreq[ch] = 1;
        }
    }

    std::cout << "Task 2" <<std::endl << "Byte freq:\n";
    for (auto & i : bytesFreq) {
        std::cout << i.first <<" (" <<
        std::bitset<8>(int(i.first)) <<"): " << i.second
        << "\t|\t" << i.second/size<<std::endl;
    }

    std::cout << std::endl;
    in.close();

    return 0;
}