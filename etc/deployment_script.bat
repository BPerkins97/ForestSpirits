cd ../business
dotnet build
cd ..
del persistence\bin\Debug\netstandard2.0\ForestSpirits.dll
del persistence\bin\Debug\netstandard2.0\ForestSpirits.pdb
del frontend\Forest_Spirits\Assets\ForestSpirits.dll
del frontend\Forest_Spirits\Assets\ForestSpiritsPersistence.dll
copy business\bin\Debug\netstandard2.0\ForestSpirits.dll persistence\bin\Debug\netstandard2.0\ForestSpirits.dll
copy business\bin\Debug\netstandard2.0\ForestSpirits.pdb persistence\bin\Debug\netstandard2.0\ForestSpirits.pdb
copy business\bin\Debug\netstandard2.0\ForestSpirits.pdb frontend\Forest_Spirits\Assets\ForestSpirits.dll
cd persistence 
dotnet build
cd ..
copy persistence\bin\Debug\netstandard2.0\ForestSpiritsPersistence.dll frontend\Forest_Spirits\Assets\ForestSpiritsPersistence.dll

pause 
