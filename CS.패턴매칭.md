## 패턴 매칭
- 선언 패턴
```csharp
if(foo is int f){
    Console.WriteLine(f);
}
```
- 형식 패턴
```csharp
if(foo is int){
    Console.WriteLine(foo);
}
```
- 상수 패턴
``` csharp
var GetCountryCode=(string nation)=> nation switch
{
    "KR"=>82,
    "US"=>1,
    "UK"=>44,
    _=>throw new ArgumentException("Not supported Code")
};
Console.WriteLine(GetCountryCode("KR"));
```
- 프로퍼티 패턴
``` csharp
class Car{
    public string Model{get;set;}
    public DateTime PruducedAt{get;set;}
}
static string GetNick(Car car)
{
    var Generatemessage=(Car car,string nick)=>
        $"{car.Model} produced in {car.ProducedAt.Year} is {nick}";
    
    if(car is Car{Model:"Mustang", ProducedAt.Year:1967})
        return Generatemessage(car,"Fastback");
    else
        return Generatemessage(car,"Unknown);
}
```
- 괄호패턴
```csharp
if(age is (int and >19)){
    Console.WriteLine(age);
}
```