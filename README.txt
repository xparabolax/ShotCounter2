This project was compiled using a package manager added into Visual studio 2013
https://www.nuget.org/

In Visual studio, you can then open this manager in the TOOLS dropdown 
and open the pachage manager console.
type the following into the console to install Costura which bundles the HockeyEditor.dll
with the exe so it runs on any computer:

Install-Package Costura.Fody

Install-CleanReferencesTarget



This might not be needed to edit and recompile the ShotCounter project, but it is
information that might be needed for others and is a good idea to include.