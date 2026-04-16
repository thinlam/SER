hey yo muốn copy cái print đem đi phải thêm dòng này cho folder Template

```csharp
<ItemGroup>
  <None Include="PrintTemplates\**\*.*">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>

```

B1. Tạo template PrintTemplates/ten_file.xlsx

B2. Tạo Store 

B3. Tạo api trong controller 