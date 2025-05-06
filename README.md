

# Tuna.Revit.Extensionss

![GitHub](https://img.shields.io/github/license/shichuyibushishiwu/Tuna.Revit.Extensions?label=License)
![GitHub](https://img.shields.io/badge/Shiwu-Tuna-green)
![GitHub](https://img.shields.io/nuget/dt/Tuna.Revit.Extensions?style=flat&logo=nuget&label=nuget&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FTuna.Revit.Extensions%2F)

## 简介

Tuna.Revit.Extensionss 是一个为 Autodesk Revit API 开发的强大扩展包，旨在简化 Revit 二次开发过程，提高开发效率。通过提供一系列实用工具和扩展方法，使 Revit API 的使用变得更加简单和直观。

## 功能特点

- 简化常见 Revit API 操作
- 提供丰富的扩展方法
- 支持多个 Revit 版本
- 易于集成到现有项目中
- 持续更新和维护

## 文档

详细的使用文档和API参考，请访问我们的官方文档：
[官方文档](https://shichuyibushishiwu.github.io/)

## 支持的 Revit 版本

* Revit 2016
* Revit 2017
* Revit 2018
* Revit 2019
* Revit 2020
* Revit 2021
* Revit 2022
* Revit 2023
* Revit 2024
* Revit 2025
* Revit 2026

## 安装方式

### 通过 NuGet 包管理器

```bash
dotnet add package Tuna.Revit.Extensions --version 2025.0.17
```







或在 Visual Studio 的 NuGet 包管理器中搜索 `Tuna.Revit.Extensions`。

## 快速开始

以下是一个简单的示例，展示如何使用 Tuna.Revit.Extensionss：

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Tuna.Revit.Extensions;

namespace MyRevitApp
{
    public class MyCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            
            // 使用 Tuna.Revit.Extensions 的扩展方法
            Wall wall = doc.GetElement("wall_id") as Wall;
            double length = wall.GetLength();
            
            // 更多操作...
            
            return Result.Succeeded;
        }
    }
}
```

## 主要模块

- **元素操作** - 简化元素的创建、修改和查询
  - 快速获取和筛选元素
  - 批量处理元素属性
  - 元素创建和复制的简化方法
  - 元素关系管理（如主从关系）

- **几何处理** - 提供强大的几何计算和转换功能
  - 点、线、面的高级操作
  - 复杂几何体的创建与变换
  - 碰撞检测与干涉检查
  - 几何数据的导入导出

- **参数管理** - 轻松访问和修改元素参数
  - 参数批量读写
  - 共享参数创建与管理
  - 参数约束与验证
  - 参数映射与转换

- **事务处理** - 简化事务操作，提高代码可读性
  - 链式事务操作
  - 事务回滚与恢复
  - 事务组合与嵌套
  - 异常安全的事务封装

- **视图工具** - 视图创建和管理的辅助方法
  - 视图模板应用
  - 视图过滤器管理
  - 多视图协同操作
  - 视图导出与打印

## 贡献指南

我们热忱欢迎社区贡献！如果您想为项目做出贡献，请遵循以下步骤：

1. **Fork 本仓库** - 在 GitHub 上点击"Fork"按钮创建您自己的副本
2. **创建特性分支** - `git checkout -b feature/amazing-feature`
3. **提交您的更改** - `git commit -m '添加某个惊人的特性'`
4. **推送到分支** - `git push origin feature/amazing-feature`
5. **开启 Pull Request** - 返回您的 GitHub 仓库，点击"New Pull Request"

### 代码规范
- 遵循 C# 编码规范
- 为所有公共 API 添加 XML 文档注释

## 许可证

本项目采用 MIT 许可证 - 详情请参阅 [LICENSE](LICENSE) 文件。

## 联系方式

如有问题或建议，请通过以下方式联系我们：

- **GitHub Issues**: [提交问题](https://github.com/shichuyibushishiwu/Tuna.Revit.Extensions/issues)
- **邮箱**: 1012201478@qq.com
- **微信公众号**: ITuna

## 致谢

衷心感谢所有为这个项目做出贡献的开发者和用户。特别鸣谢：

- 所有提交代码的贡献者
- 提供宝贵反馈的用户
- Autodesk Revit API 社区
- 开源社区的支持与鼓励

---

*Tuna.Revit.Extensionss - 让 Revit 开发更简单、更高效*




        

