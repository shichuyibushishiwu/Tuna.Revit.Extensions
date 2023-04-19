

![GitHub](https://img.shields.io/github/license/shichuyibushishiwu/Tuna.Revit.Extension?label=License)
![GitHub](https://img.shields.io/badge/Shiwu-Tuna-green)
# Introductions
Welcome to the Tuna.Revit.Extensions wiki! This is a extension package for revit api.

# Guide
## Constants
* [内置类别(BuiltInCategories)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/BuiltInCategories)
* [内置参数(BuiltInParameters)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/BuiltInParameters)

## Revit Api Extension

* [用户选择(Selection)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Selection)
* [图元查询(ElementFilter)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/ElementFilter)
  - [文档内(InDocument)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/ElementFilterInDocument)
  - [视图内(InView)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/ElementFilterInView)
  - [列表内(InList)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/ElementFilterInList)
* [图元(Element)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Element)
* [参数(Parameter)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Parameter)
* [材质(Materials)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Materials)
  - [颜色(Color)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Color)
  - [外观(Appearance)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Appearance)
* [事务(Transaction)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Transaction)
* [图形(Geometry)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Geometry)
* [单位转换(UnitConverter)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/UnitConverter)
* [界面(Ribbon)](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/wiki/Ribbon)

## Revit Api Service


# Samples

## Document
``` C#
document.NewTransaction(()=>
{
    //do someting...
}) 
```
## RibbonUI
```C#
panel.CreateButton<CreateWallCommand>((b)=>
{
    //do someting...
})
```


# Support Version

* Revit 2016
* Revit 2017
* Revit 2018
* Revit 2019
* Revit 2020
* Revit 2021
* Revit 2022
* Revit 2023

# Install

```
 > dotnet add package Tuna.Revit.Extension --version 2021.0.0
```










