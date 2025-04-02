#include <iostream>
#include <string>
#include <fstream>
#include <map>
#include <algorithm> 
#include <vector>

bool compareByKey(std::pair<std::string, int>& a, std::pair<std::string, int>& b) 
{ 
    return a.first < b.first; 
} 

bool compareByValue(std::pair<std::string, int>& a, std::pair<std::string, int>& b) 
{ 
    return a.second > b.second; 
} 

std::map<std::string, int> ReadFromFile(const std::string &strFilePath)
{
    std::ifstream file(strFilePath);
    std::string strFileContent;
    std::map<std::string, int> wordsCount;
    while (file >> strFileContent)
    {
        std::transform(strFileContent.begin(), strFileContent.end(), strFileContent.begin(), tolower);
        if(wordsCount.find(strFileContent) != wordsCount.end())
        {
            wordsCount[strFileContent]++;
        }
        else
        {
            wordsCount[strFileContent] = 1;
        }
    }

    return wordsCount;
}

int main()
{
    std::map<std::string, int> wordsCount = ReadFromFile("TestFile.txt");
    std::vector<std::pair<std::string, int> > vecWordsFrequency; 
    for (auto& wordFrequency : wordsCount) 
    { 
        vecWordsFrequency.push_back(wordFrequency); 
    } 
 
    std::sort(vecWordsFrequency.begin(), vecWordsFrequency.end(), compareByValue);
    vecWordsFrequency.erase(vecWordsFrequency.begin() + 10, vecWordsFrequency.end());
    std::sort(vecWordsFrequency.begin(), vecWordsFrequency.end(), compareByKey);
    
    for(auto& kv : vecWordsFrequency)
    {
        std::cout << "Word : " << kv.first << " --> Frequency : " << kv.second << std::endl;
    }
}