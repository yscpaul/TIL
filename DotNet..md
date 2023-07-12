### 개발 환경 셋팅
- Visual Studio
- Font : Cascadia Code-14
- dotPeek
- GitHub Codespaces

### What's in the SDK?
- .Net CLI
  - CLI Command : new restore build run publish test vtest  pack clean sln help store workload
  ```Command
  dotnet workload install maui 
  dotnet new -h
  dotnet new console -o ./Console1
  dotnet new console -o ./Console1 -lang f#
  dotnet build
  dotnet run
  dotnet workload -h
  dotnet workload list
  ```

- Dotnet driver
- .Net Libraries
- Runtimes

### .Net6
참고
https://github.com/LinkedInLearning/NET6-deep-dive-2894045 

### JSON
- Create partial class
- Indicate the type to serialize/deserialize
- Build project (which generates some partial classes)
- Call JsonSerializer.Serialize(data,context)
- Call JsonSerializer.Deserialize
- 