# Arita
Ueqt's common c# library

## ƴ��  
1. ȫƴ���������֣�  
``` C#
AritaPinYinHelper.GetPinYinFullList("���")
```  
���: "JIGUAI", "QIGUAI"  

2. ȫƴ����ĸ���������֣�
``` C#
AritaPinYinHelper.GetPinYinInitialList("���")
```  
���: "JG", "QG"  

## ����ת��  
1. byte[]תstruct  
``` C#
new byte[] {}.ToStruct();
```  

2. structתbyte[]  
``` C#
new xxx().StructToBytes();
```  

3. ʱ���ת����
``` C#
Assert.AreEqual("20060822", 1156219870.GetLocalTimeFromUtcTimeSpan().ToString("yyyyMMdd"));
```  


