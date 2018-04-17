# HostHelper 

使用C#编写的一款简单方便的管理HOST指向记录的小工具，可方便切换HOST指向。公司常用在开发测试环境模拟真实线上的域名配置。

![screenshot](https://github.com/bywei/HostHelper/raw/master/Screenshots/hosthelper.png)
![screenshot](https://github.com/bywei/HostHelper/raw/master/Screenshots/hosthelper14.jpg)

HostHelper经历了前面几个小版本，功能逐渐的增强。使做开发和测试工作的朋友节省了工作时间，提高了工作的效率，希望能为大家受用。

# 使用说明

1.下载 ‘HostHelper v1.1’（csdn,程序员百味 官网，51cto 均有下载地址），解压后，移动.exe可执行文件到自己的工作目录，建议不要放到桌面。

2.双击运行后，文件会自动生成两个文件，一个icon和一个配置文件（运行时，可能会有杀毒软件提示修改host或者开机项，请放心使用 并无病毒）

3.初次使用配置文件为空，请在'host管理’中点击‘配置文件格式’即可查看配置样式。

4.按照所需配置host,完毕点击保存。（注意：分组名即为托盘图标的菜单名，不可重复）

5.右键点击右下角host助手托盘图标，单击组可以设置包含子菜单的所有host,单击子选项，可配置单个host选项。

6.该版本可以配置小的选项（主配置），也可以配置更多的地址，方便与更高需求。

> 本工具是直接管理host文件，请提前做好文件的备份，防止重要记录丢失！切记~~~ 

# 版本说明
```
HostHelper v1.0 完全自主配置 切换Host

HostHelper v1.1 修复开机自动运行时无法读取原配置文件. 
注意：
（1）V1.0升级时需要删除原来的自动运行注册表值
（2）如无法删除注册表值，请用新文件覆盖V1.0文件

HostHelper v1.2 修改了示例提示及部分异常提示信息

HostHelper v1.3 对代码进行简单的优化（稳定）

HostHelper v1.4 增强了功能，可配置单独文件（便于大量的host指向）

```
## 关于作者

bywei = 程序员百味

个人博客 = "http://www.bywei.cn"







