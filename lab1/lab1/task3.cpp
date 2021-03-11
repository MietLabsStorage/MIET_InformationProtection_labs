#include "task3.h"
#include <iostream>
#include <fstream>
#include <string>

int task3run() {
    std::cout << "Task 3" <<std::endl;
    encode();
    decode();
    std::cout <<std::endl;
    return 0;
}

void encode(){
    //read keys from file
    std::ifstream in_k("Keys.txt", std::ios::in | std::ios::binary);
    if (!in_k) {
        std::cout << "Cannot open file.\n";
        return (void)"";
    }
    int8_t keys[256];
    int i = 0;
    std::string line;
    while (getline(in_k, line))
    {
        keys[i] = std::stoi(line, nullptr, 2);
        i++;
    }
    in_k.close();

    //read message form file
    //encode and write in file
    std::ofstream out("Encoded.jpg", std::ios::out | std::ios::binary);
    std::ifstream in("task1.jpg", std::ios::in | std::ios::binary);
    char uncoded;
    while (in.read(&uncoded, 1)) {
        char byte = char(keys[uint8_t((unsigned char)uncoded)]);
        out.write(&byte, 1);        
    }
    out.close();
    in.close();
    std::cout<<"End encoding"<<std::endl;

}

void decode(){
    //read keys from file
    std::ifstream in_k("Keys.txt", std::ios::in | std::ios::binary);
    if (!in_k) {
        std::cout << "Cannot open file.\n";
        return (void)"";
    }
    int8_t keys[256];
    int i = 0;
    std::string line;
    while (getline(in_k, line))
    {
        keys[std::stoi(line, nullptr, 2)] = i;
        i++;
    }
    in_k.close();

    //read message form file
    //encode and write in file
    std::ofstream out("Decoded.jpg", std::ios::out | std::ios::binary);
    std::ifstream in("Encoded.jpg", std::ios::in | std::ios::binary);
    char encoded;
    while(in.read(&encoded, 1)){
        char byte = char(keys[int((unsigned char)encoded)]);
        out.write(&byte, 1);
    }
    out.close();
    in.close();
    std::cout << "End decoding" << std::endl;
}