mkdir nuget
mkdir nuget\lib
mkdir nuget\lib\net451
copy bin\FunctionalNET.dll nuget\lib\net451
copy bin\FunctionalNET.pdb nuget\lib\net451
copy bin\FunctionalNET.XML nuget\lib\net451
copy Functional.nuspec nuget
cd nuget
nuget pack Functional.nuspec