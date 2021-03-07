#include "task1.h"
#include <iostream>
#include <fstream>

int task1run() {
    //system("chcp 1251");
   // setlocale(0, "RUS");
    //читаем файл
    std::ifstream in("task1.txt", std::ios::in | std::ios::binary);
    if (!in) {
        std::cout << "Cannot open file.\n";
        return 1;
    }

    //перемещение указателя в конец
    in.seekg(0,std::ios::end);
    //определение текущей позиции указателя
    long counter = in.tellg();

    std::cout << "Task 1" <<std::endl <<
    "Byte length: " << counter << std::endl;

    std::cout << std::endl;
    in.close();

    return 0;
}
