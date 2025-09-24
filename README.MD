[한글](README.kr.md)

# CSV to CSV Converter

This is a Windows Forms application that reads and processes CSV files, generating a new CSV file based on the selected task.

## Features

- **CSV Processing:** Reads data from a user-selected CSV file.
- **Multiple Tasks:** Supports different processing tasks:
  - **Get Downloads Info:** Enriches the input CSV by calling an external API to fetch additional file path information and then joins this data with the original content.
  - **Get Folder Info:** Processes CSV data related to folder information.
- **Dynamic Output:** Generates a new CSV file with a dynamically created name that includes the date range and department.
- **Simple UI:** Provides a simple interface to select the task, choose the input file, and run the conversion.

## How to Use

1.  **Run the application.**
2.  **Select a Task:** Choose either "Get Downloads Info" or "Get Folder Info" from the dropdown menu.
3.  **Select a File:** Click the "Open File" button to select the source CSV file.
4.  **Enter Details:** Fill in the department name and select the date range.
5.  **Start Conversion:** Click the "Start" button (the button text will reflect the selected task) to begin the process.
6.  **Output:** A new CSV file will be created in the same directory as the input file. The new file will be named in the format: `yy-MM-dd_yy-MM-dd_Department_Task_로그.csv`.

## Dependencies

- [CsvHelper](https://joshclose.github.io/CsvHelper/) for CSV parsing.
- An external API for the "Get Downloads Info" task, which must be configured in the application's configuration file.

