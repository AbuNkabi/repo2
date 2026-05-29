# repo2
# cybersecuritybot
CybersecurityChatBot is a C# WPF application that teaches users about safety online through interactive conversations,memory recall and personalised responses.
Abulele Nkabi ST10483049
# Installation and Setup Guide

## Prerequisites

Before running the project, make sure the following software is installed:

* Visual Studio 2022
* .NET 8.0 SDK
* Windows Operating System

# Step-by-Step Instructions to Clone and Run the Project

## 1. Clone the Repository

Open Git Bash or Command Prompt and run:

```bash
https://github.com/AbuNkabi/cybersecuritybot.git
```

Replace the link with your actual GitHub repository URL.
 2. Open the Project

1. Open Visual Studio 2022
2. Click **Open a project or solution**
3. Navigate to the cloned `CybersecurityChatbot` folder
4. Open the `.sln` solution file

 3. Restore Dependencies

Visual Studio will automatically restore the required .NET packages when the project opens.

If prompted:

* Click **Restore**

 4. Check the Target Framework

1. Right-click the project in Solution Explorer
2. Select **Properties**
3. Under **Application**, confirm the Target Framework is:

```text
.NET 8.0
```
 5. Add the Greeting Audio File

The chatbot uses a startup voice greeting called:

```text
greeting.wav
```

Place the file directly inside the main project folder:

```text
CybersecurityChatbot/
│
├── greeting.wav
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── ChatBot.cs
```

Important:

* The file name must be exactly:

```text
greeting.wav
```

* The file must NOT be placed inside:

  * bin/
  * Debug/
  * Downloads/
  * Documents/

 6. Configure the WAV File

In Visual Studio:

1. Locate `greeting.wav` in Solution Explorer
2. Click the file
3. Open the **Properties** window
 7. Build the Project

In Visual Studio:

```text
Build → Clean Solution
```

Then:

```text
Build → Rebuild Solution
```

 8. Run the Application

Press:

```text
F5
```

OR click the green **Start** button in Visual Studio.

The WPF chatbot window should open with:

* ASCII art
* Chat interface
* Voice greeting
* Cybersecurity chatbot functionality


# Features Included

* GUI chatbot interface
* ASCII art display
* Voice greeting
* Keyword recognition
* Random responses
* Sentiment detection
* Memory and recall
* Conversation flow
* Cybersecurity awareness tips
