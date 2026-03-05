#include <bits/stdc++.h>
using namespace std;

void odwracanie(string str) {
    stack<char> stos;
    for (int i = 0; i < str.length(); i++) {
        stos.push(str[i]);
    }
    while(!stos.empty()) {
        cout << stos.top();
        stos.pop();
    }
}

bool palindrome(string str) {
    stack<char> stos;
    int dlugosc = str.size();

    int start = ((dlugosc%2==0) ? dlugosc/2 : dlugosc/2+1);

    for (int i = 0; i < dlugosc/2; i++) {
        stos.push(str[i]);  
    }
    for (int i = start; i < dlugosc; i++) {
        if (stos.top() != str[i]) return false;
        stos.pop();
    }
    return true;
}

void placki() {
    int n;
    char a;
    double b;
    cin >> n;
    stack<double> placki;
    while(n--) {
        cin >> a;
        if(a == '+') {
            cin >> b;
            placki.push(b);
        }
        else if(a == '?') {
            cout << fixed << setprecision(2) << placki.size() << " ";
        }
        else {
            cout << fixed << setprecision(2) << placki.top() << " ";
            placki.pop();
        }

    }
}

void stos_i_arytmetyka() {
    int n; cin >> n;
    int j;
    stack<int> stos;
    while(n--) {
        cin >> j;
        if (j == 1) {
            int a;
            cin >> a;
            stos.push(a);
        }
        else {
            char a;
            cin >> a;
            int x = stos.top();
            stos.pop();
            int y = stos.top();
            stos.pop();
            if (a == '+') {
                stos.push(y+x);
            }
            else if (a == '-') {
                stos.push(y-x);
            }
            else if (a == '*') {
                stos.push(y*x);
            }
            else {
                stos.push(y/x);
            } 
        }
    }
    cout << stos.top() << "ONP";
}

int main() {
    cout << (palindrome("abcba") ? "palindrom" : "nie palindrom") << "\n";
    odwracanie("przemek");
    placki();
    stos_i_arytmetyka();
    return 0;
}
