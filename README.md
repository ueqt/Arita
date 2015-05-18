# Arita
Ueqt's common c# library

## 拼音  
1. 全拼（含多音字）  
``` C#
AritaPinYinHelper.GetPinYinFullList("奇怪")
```  
输出: "JIGUAI", "QIGUAI"  

2. 全拼首字母（含多音字）
``` C#
AritaPinYinHelper.GetPinYinInitialList("奇怪")
```  
输出: "JG", "QG"  

## 类型转换  
1. byte[]转struct  
``` C#
new byte[] {}.ToStruct();
```  

2. struct转byte[]  
``` C#
new xxx().StructToBytes();
```  

3. 时间戳转日期
``` C#
Assert.AreEqual("20060822", 1156219870.GetLocalTimeFromUtcTimeSpan().ToString("yyyyMMdd"));
```  


