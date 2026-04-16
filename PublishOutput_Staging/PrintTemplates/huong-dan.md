Hiện tại có thể thoải mái thay đổi giá trị đầu ra miễn trùng với $Value trong template 

ví dụ template bạn khai báo $TenDuAn thì ở store procedure bạn phải trả về là TenDuAn

Nếu bạn cần đổi những cái sau vui lòng nhắn dev
1. Đổi tên store Procedure 
2. Đổi/thêm thứ tự của parameters


SETUP:
1. Copy file LicenseAsposeTotal.lic trong Properties qua source cần dùng

```csharp  
    <ItemGroup>
        <None Remove="Properties\LicenseAsposeTotal.lic" />
        <EmbeddedResource Include="Properties\LicenseAsposeTotal.lic" />
    </ItemGroup>
```
2. Copy các helper liên quan đến Aspose mà tôi đã viết
3. Tạo folder PrintTemplates hoặc cấu trúc tùy bạn thích rồi add vào project.
   
Mục đích là khi build hay publish project thì cũng mang cả folder này đi theo

```csharp  
    
    <ItemGroup>
        <None Include="web.config">
            <ExcludeFromSingleFile>true</ExcludeFromSingleFile>
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
            <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
        </None>
        <None Include="PrintTemplates\**\*.*">
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
    </ItemGroup>
```
