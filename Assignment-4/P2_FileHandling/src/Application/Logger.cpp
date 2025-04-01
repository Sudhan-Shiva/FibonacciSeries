#include "Logger.hpp"

int CLogger::GetNumberOfFilesInDirectory(const std::string& folder) 
{
    DIR* directory = opendir(folder.c_str());
    struct dirent* entry;
    int numberOfFiles = 0;

    while (entry = readdir(directory)) 
    {
        std::string fileName = entry->d_name;

        if (!(fileName == "." || fileName == ".."))
        {
            numberOfFiles++;
        }
    }

    closedir(directory);
    return numberOfFiles;
}

long CLogger::GetDirectorySize(const std::string& folder) 
{
    DIR* directory = opendir(folder.c_str());
    struct dirent* entry;
    long totalSize = 0;

    while (entry = readdir(directory)) 
    {
        std::string fileName = entry->d_name;

        if (!(fileName == "." || fileName == ".."))
        {
            std::string filePath = folder + "/" + fileName;
            std::ifstream file(filePath, std::ios::ate);
            totalSize += file.tellg(); 
            file.close();
        }
    }

    closedir(directory);
    return totalSize;
}

void CLogger::PrintListOfFiles(const std::string& folder) 
{
    DIR* directory = opendir(folder.c_str());
    struct dirent* entry ;

    while (entry = readdir(directory)) 
    {
        std::string fileName = entry->d_name;

        if (!(fileName == "." || fileName == ".."))
        {
            std::string filePath = folder + "/" + fileName;
            std::ifstream file(filePath, std::ios::ate);
            std::cout << folder + "/" + fileName + " --> File Size : " + std::to_string(file.tellg()) + " bytes" << std::endl;
        }
    }

    closedir(directory);
}

void CLogger::LogDateTime()
{
    std::string filePrefix = "Logs/LoggedData_";
    std::string fileExtension = ".txt";
    int fileNumber = GetNumberOfFilesInDirectory("Logs");
    std::fstream file((filePrefix + std::to_string(fileNumber) + fileExtension), std::ios::app | std::ios::ate);
    int fileSize = 0;
    while (!m_shouldStopLogging.load())
    { 
        if(GetDirectorySize("Logs") < MAX_DIRECTORY_SIZE)
        {
            if(fileSize < MAX_FILE_SIZE)
            {
                time_t timestamp;
                time(&timestamp);
                file << ctime(&timestamp);
                std::this_thread::sleep_for(std::chrono::seconds(1));
                fileSize = file.tellg();
            }
            else
            {
                file.close();
                fileNumber = GetNumberOfFilesInDirectory("Logs");
                file.open((filePrefix + std::to_string(fileNumber) + fileExtension), std::ios::app | std::ios::ate);
                fileSize = 0;
            }
        }

        else
        {
            file.close();

            int numberOfFiles = GetNumberOfFilesInDirectory("Logs");
            std::remove((filePrefix + std::to_string(numberOfFiles) + fileExtension).c_str());
            for(int fileCount = 0; fileCount <=4; fileCount++)
            {     
                std::remove((filePrefix + std::to_string(fileCount) + fileExtension).c_str());
            }

            for(int fileCount = 5; fileCount < numberOfFiles; fileCount++)
            {
                std::rename((filePrefix + std::to_string(fileCount) + fileExtension).c_str(), (filePrefix + std::to_string(fileCount - 5) + fileExtension).c_str());
            }

            numberOfFiles = GetNumberOfFilesInDirectory("Logs");
            file.open((filePrefix + std::to_string(numberOfFiles-1) + fileExtension), std::ios::app | std::ios::ate);
        }
    }
}