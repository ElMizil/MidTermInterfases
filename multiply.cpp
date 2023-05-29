#include "multiply.hpp"

    int* multi100(int x, int y){
    x = x*100;
    y = y*100;
    int* val = new int[2];
    val[0] = x;
    val[1] = y;
    return val;

    }

