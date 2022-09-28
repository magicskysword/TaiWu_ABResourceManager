# TaiWu_ABResourceManager

## 介绍
这是一个为太吾绘卷正式版提供Mod的AB包加载的库

## 作用
通过使用本库，可以方便的将Unity里的资源进行打包，并在游戏内加载

## 准备工作
Unity 2018.4.23
任意脚本编辑器

## 使用方法
### 1.打包资源

使用Unity 2018.4.23打开UnityProject工程。

在工程的`Assets/BuildResource`文件夹内放置需要打包的资源，如：
```
Assets/BuildResource/UI/abc.prefab
Assets/BuildResource/Sprite/img.sprite
```
然后使用顶部的`Mod工具/打包Mod资源包`一键打包资源

打包的资源位于该库根目录下的：`Bundle`文件夹

### 2.复制脚本
打开ABResourceManager.sln解决方案，其中`ABResourceManager.cs`文件即是核心资源加载脚本。

注：其实也可以手动加载与管理AB包，不过对AB包操作不熟悉的话推荐先使用该脚本。

把`ABResourceManager.cs`复制到你的工程并修改命名空间

### 3.依赖管理
导入脚本后，还需要从游戏的dll中导入更多相关dll，需要导入的dll如下：
```
Assembly-CSharp
TaiwuModdingLib
UnityEngine
UnityEngine.AssetBundleModule
UnityEngine.CoreModule
```

### 4.脚本初始化
在继承`TaiwuRemakePlugin`类的核心脚本中，

在`Initialize()`方法中调用

```C#
ABResourceManager.Init(ModIdStr);
```
进行初始化并加载AB包

在`Dispose()`方法中调用

```C#
ABResourceManager.UnInit();
```
进行反初始化与卸载AB包

### 5.资源加载
进行了初始化后，在脚本之中即可自由读取Mod包的资源。需要注意的是在打包之后Mod的路径会进行变更，如
```
Assets/BuildResource/UI/abc.prefab
Assets/BuildResource/Sprite/img.sprite
```
打包后的路径为
```
UI/abc.prefab
Sprite/img.sprite
```

使用ABResourceManager里的相关方法即可加载资源或实例化预制体，如：
```C#
// 实例化预制体
ABResourceManager.Instantiate("UI/abc.prefab");

// 读取精灵资源
ABResourceManager.LoadAsset<Sprite>("Sprite/img.sprite");
```