namespace SharedKernel.CrossCuttingConcerns.Offices;

public class AsposeResult
{
    public required byte[] FileBytes { get; set; }
    public required string ContentType { get; set; }
}

public class AsposeInstruction<T>
{
    public required string TemplatePath { get; set; }
    public required List<T> Items { get; set; }
    public List<string> HiddenColumns { get; set; } = [];
    public List<MergeInstruction>? MergeInstructions { get; set; }
}
