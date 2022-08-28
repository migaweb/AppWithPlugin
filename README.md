# AppWithPlugin

Classic service layer architecture using plugins in the database layer.

## Plugin
A database plugin consist of a core set of tables. 
A plugin consists of tables that extend the core set of tables 
(e.g. the table PluginArticle is an extension of the table Article)
as well as additional standalone set of tables.

## Solution
Using the decorator pattern on the service layer level allows to
extend the behavior of the core service with new functionality.
The extended service class uses the specialized DbContext for the plugin.

A generic controller allows us to use the same code for all  plugins 
as well as extending a plugin controller with additional
functionality.

