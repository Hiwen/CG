### 这是一个Visual Studio 2019的Cg脚本语言扩展插件

* 最近工作中需要编写Cg脚本，没有合适的编辑器，就用vs写。但是vs没有Cg的高亮及语法提示的插件。
* 在NuGet上找到了GLSL的扩展插件，对于GLSL还是很好用的。
* 不过不能直接支持Cg（其实在选项中可以将glsl后缀修改为cg，但是不能很好的识别很cg关键字）。
* 后来在Github上找到了GLSL插件的源码：https://github.com/danielscherzer/GLSL
* 非常高兴，非常感谢原作者：Daniel Scherzer。
* 基于GLSL的插件，自己修改了一下，用于Cg的编写。

### TODO:
* 完善关键字，函数列表，变量列表


