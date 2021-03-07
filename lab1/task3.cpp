#include "task3.h"
#include <iostream>
#include <fstream>
#include <cstring>

int task3run() {
    //system("chcp 1251");
    // setlocale(0, "RUS");
    std::cout << "Task 2" <<std::endl;
    char* mes = (char*)"I want some pizza)\nand \tany more";
    std::cout << mes <<std::endl;
    char* encoded = encode(mes);
    std::cout << encoded <<std::endl;
    char* decoded = decode(encoded);
    std::cout << decoded <<std::endl;
    return 0;
}

char* encode(char* mes){
    std::ifstream in("Keys.txt", std::ios::in | std::ios::binary);
    if (!in) {
        std::cout << "Cannot open file.\n";
        return (char*)"";
    }
    int keys[255];
    int i = 0;
    if (in.is_open())
    {
        std::string line;
        while (getline(in, line))
        {
           keys[i] = std::stoi(line, nullptr,2);
           i++;
        }
    }
    char* encodedMes = new char[strlen(mes)+1];
    for(int j = 0; j < strlen(mes); j++){
        //std::cout << mes[j] << int((unsigned char)mes[j]) << " " << keys[int((unsigned char)mes[j])]<< " "<<char(keys[int((unsigned char)mes[j])])<< std::endl;
        encodedMes[j] = char(keys[int((unsigned char)mes[j])]);
    }
    in.close();
    //std::cout<<strlen(mes)<<" "<<strlen(encodedMes)<<std::endl;
    return encodedMes;
}

char* decode(char* mes){
    std::ifstream in("Keys.txt", std::ios::in | std::ios::binary);
    if (!in) {
        std::cout << "Cannot open file.\n";
        return (char*)"";
    }
    int keys[255];
    int i = 0;
    if (in.is_open())
    {
        std::string line;
        while (getline(in, line))
        {
            keys[std::stoi(line, nullptr,2)] = i;
            i++;
        }
    }
    char* decodedMes = new char[strlen(mes)+1];
    for(int j = 0; j < strlen(mes); j++){
        //std::cout << mes[j] << int((unsigned char)mes[j]) << " " << keys[int((unsigned char)mes[j])]<< " "<<char(keys[int((unsigned char)mes[j])])<< std::endl;
        decodedMes[j] = char(keys[int((unsigned char)mes[j])]);
    }
    in.close();
    //std::cout<<strlen(mes)<<" "<<strlen(decodedMes)<<std::endl;
    return decodedMes;
}