# XAML Data binding 

XAML 데이터 바인딩(Data Binding)은 XAML 마크업 언어를 사용하여 UI 요소와 데이터 소스를 연결하는 기술입니다. 데이터 바인딩을 사용하면 UI 요소에 동적으로 데이터를 표시하거나 사용자 입력에 대한 데이터를 처리하는 등의 작업을 간편하게 처리할 수 있습니다.

XAML 데이터 바인딩의 구성 요소는 다음과 같습니다.

1. 소스(Source): 데이터 바인딩에 사용할 데이터 소스입니다. 데이터 소스는 보통 ViewModel, Model 또는 데이터베이스와 같은 데이터 스토어입니다.
2. 타겟(Target): 데이터를 바인딩할 UI 요소입니다. 예를 들어, Label의 Content 속성이나 TextBox의 Text 속성 등이 될 수 있습니다.
3. 바인딩(Binding): 소스와 타겟을 연결하는 데 사용되는 바인딩 객체입니다. 바인딩 객체는 데이터 소스와 UI 요소 간의 데이터 흐름을 설정하고, UI 요소의 속성 변경을 데이터 소스에 반영할 수 있도록 합니다.
4. 변환기(Converter): 데이터 소스와 UI 요소 간의 형식이 다를 경우, 데이터를 변환하는 데 사용됩니다. 예를 들어, 데이터 소스에서 전달된 값을 통화 형식으로 변환하는 변환기를 만들 수 있습니다.

아래는 XAML 데이터 바인딩의 예시입니다.

~~~xml
 <TextBlock Text="{Binding Name}" />
~~~

위의 예시에서, TextBlock 요소의 Text 속성은 데이터 소스의 Name 속성에 바인딩됩니다. 이렇게 바인딩을 설정하면 데이터 소스의 Name 속성 값이 변경될 때마다 TextBlock의 Text 속성도 자동으로 업데이트됩니다.

XAML 데이터 바인딩은 MVVM(Model-View-ViewModel) 아키텍처와 함께 사용될 때 가장 유용합니다. MVVM 아키텍처는 UI와 비즈니스 로직을 분리하여 개발하고, 데이터 바인딩을 사용하여 View와 ViewModel 사이의 데이터 흐름을 쉽게 처리할 수 있도록 합니다.

# XAML 바인딩에서 '#' # 
XAML에서 바인딩 표현식에서 # 기호는 정적 리소스 참조(Static Resource Reference)를 나타냅니다. # 기호는 XAML에서 사용되는 다른 표현식과 구분하기 위해 사용되며, 대개 {StaticResource} 표현식과 함께 사용됩니다.

정적 리소스 참조를 사용하면 XAML에서 정의한 리소스(예: 스타일, 데이터 템플릿, 컬러 등)를 다른 요소에서 참조할 수 있습니다. 예를 들어, 다음과 같이 정적 리소스 참조를 사용하여 TextBox의 스타일을 정의하고 적용할 수 있습니다.

xml
Copy code
<Window.Resources>
    <Style x:Key="MyTextBoxStyle" TargetType="{x:Type TextBox}">
        <Setter Property="Foreground" Value="Red"/>
        <Setter Property="BorderBrush" Value="Gray"/>
        <Setter Property="FontSize" Value="14"/>
    </Style>
</Window.Resources>

<!-- 정적 리소스 참조를 사용하여 MyTextBoxStyle 스타일을 적용 -->
~~~xml
 <TextBox Style="{StaticResource MyTextBoxStyle}" Text="{Binding Name}"/>
~~~

위의 코드에서 Style 속성에서 정적 리소스 참조를 사용하여 MyTextBoxStyle이라는 리소스를 참조하고 있습니다. 이렇게 하면 해당 리소스에서 정의한 속성 값이 TextBox 요소에 적용됩니다.

'#' 기호는 정적 리소스 참조 외에도 다른 바인딩 표현식에서도 사용됩니다.  
예를 들어, {x:Static} 표현식에서도 # 기호를 사용하여 정적 멤버(상수, 필드, 속성 등)를 참조할 수 있습니다.
