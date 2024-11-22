using System.Reflection;

namespace ReadOnly;

internal static class Hack
{
    public static void Me(SomeConstants consts)
    {
        var constsObjType = consts.GetType();
        HackSafe(constsObjType, "MyConstValue", consts);
        HackSafe(constsObjType, "MyStaticValue", consts);
        HackSafe(constsObjType, "myFieldValue", consts);

        var staticType = typeof(SomeStaticConstants);
        HackSafe(staticType, "MyConstValue", null);
        HackSafe(staticType, "MyStaticValue", null);
    }

    private static void HackSafe(Type type, string field, object obj)
    {
        var allFieldsFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        try
        {
            type.GetField(field, allFieldsFlags).SetValue(obj, "HACK");
        }
        catch (FieldAccessException ex)
        {
            //Console.WriteLine(ex);
            //Console.WriteLine();
        }
    }
}