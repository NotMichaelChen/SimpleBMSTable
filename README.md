# SimpleBMSTable

A minimal difficulty table manager for LR2 that is designed to be a simple as possible to use.

![alt text](https://i.imgur.com/jbt6852.png "SimpleBMSTable")

# Basic Usage

1. Go to File->Select LR2 Folder, and navigate to the folder containing the LR2 executable. Click OK.
2. Enter the URL of the table that you want to load in the text box, then click "Load URL"
3. Select a table from the combo box and click "Load Table" to generate the LR2 folders and to insert tags into the LR2 database
4. Add the generated "CustomFolder" into LR2 to access the generated table

## Other notes

* To remove a table, select the table from the combo box and click "Delete Table", then click Yes.
  * This removes the tags from the database and deletes the corresponding CustomFolder.
* To regenerate a table's CustomFolder in case of level additions/deletions, click "Regenerate Folder"

# Requirements

Requires [.NET 4.6.1](https://www.microsoft.com/en-us/download/details.aspx?id=49981)
