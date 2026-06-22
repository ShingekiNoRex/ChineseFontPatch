# Chinese Font Patch 中文字体补丁

注：此MOD并非汉化补丁，支持所有使用TextMeshProUGUI的Unity游戏。

此MOD可使游戏中所有的文字都支持中文显示，不再显示方块。

使用的字体为幼圆。

# Usage 使用方法

1. 安装[BepInEx](https://github.com/BepInEx/BepInEx)至游戏根目录。
2. 下载[最新版本](https://github.com/ShingekiNoRex/ChineseFontPatch/releases)的中文字体补丁。
3. 将ChineseFontPatch.dll和FontAsset-SIMYOU放入BepInEx/plugins文件夹内。

   （若没有plugins文件夹，则创建一个）

# Issues 问题和Bug
请于[此处](https://github.com/ShingekiNoRex/ChineseFontPatch/issues)提交。

# Proton/Wine 用户注意事项：
游戏运行在 Proton 下时，需要在 Steam 启动选项中添加：
WINEDLLOVERRIDES="winhttp=n,b" %command%
否则 BepInEx 的 winhttp.dll 代理不会被 Wine 加载。
