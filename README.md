#为什么开源？

RadioWar“创立”至今已经很多年了，正如我们“团队”成员所说：“这只是一个兴趣小组，没啥的！”，所以我们虎头蛇尾的搞了一大堆“领先”国内外的“东西”出来，却没有心思和时间维护，故此我们就把手上的项目都公开，希望国内真正有心思、有时间的朋友一起维护起来！

我们把东西开源了！又有真正人来维护？最起码淘宝商家开心了！又有东西可以拿去骗钱了！

#什么是 NFCGUI ？
一款图形化NFC协议安全分析工具，主要针对Mifare卡，基于libnfc完成。

#NFCGUI版本划分
- Ganso为原始版本，功能最少，因为只是完成当时的想法而设计的。
- Pangu为功能加强，带有破解等功能，但不稳定。

公开版本只针对了nfc-list/nfc-mfclassic/nfc-mfsetuid三个程序的操作简化，接下来我们会尽量做到支持整个Libnfc开发套件。
因libnfc作为开源套件所以并不支持ACR122U为207或以上固件版本，从香港团购代购回来的ACR122U固件版本为103确认支持！ 

#NFCGUI更新日志

V0.1~0.5版本

	1.	增加自动Fixdump功能，对于mfocGUI生成的dumpfile文件进行优化，修补了其1K大小的问题。
	2.	修复DUMP文件以及KEY文件路径以及名称存在空格后，程序提示无法找到nfc-mfclassic.exe的问题。
	3.	修复一些人为错误

V1.0版本

	1.	重写NFCGUI相关代码
	2.	增加简体中文、繁体中文、英文语言选择
	3.	增加DumpFile显示功能模块
	4.	增加对于DumpFile的效验位显示
	5.	修复相关程序错误

V1.5版本（最后一个纯NFCGUI版本）

	1.	增加mfoc破解功能
	2.	增加密钥导入导出功能
	3.	增加基于MIFARE CLASSIC系列的控制位功能

#NFCGUI界面截图：
![image](http://wiki.radiowar.org/images/d/de/LibnfcGUI-RadioWar.jpg) #NFCGUI使用说明：
NFCGUI必须与编译好的libnfc放在相同目录下，否者无法执行相关命令，按照Libnfc的设备支持列表，NFCGUI支持所有基于PN532芯片解决方案，所以在香港代购回来的ACR122U使用毫无问题！

#NFCGUI是否开源 ？
NFCGUI只是一个Windows下的图形操作界面，保持了Libnfc程序的完整性，并且NFCGUI将会面向有志于共同维护该项目的朋友开源。
