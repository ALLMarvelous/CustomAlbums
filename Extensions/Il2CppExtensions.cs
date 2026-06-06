using System.Runtime.InteropServices;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppCollection = Il2CppSystem.Collections.Generic;

namespace CustomAlbums.Extensions;

public static class Il2CppExtensions
{
    public static Il2CppCollection.List<T> ToIl2Cpp<T>(this List<T> managed)
    {
        var il2Cpp = new Il2CppCollection.List<T>(managed.Count);
        foreach (var item in managed)
            il2Cpp.Add(item);
        
        return il2Cpp;
    }

    public static Il2CppCollection.Dictionary<TKey, TValue> ToIl2Cpp<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary)
    {
        var il2Cpp = new Il2CppCollection.Dictionary<TKey, TValue>(dictionary.Count);
        foreach (var (key, value) in dictionary)
            il2Cpp.Add(key, value);
        
        return il2Cpp;
    }
    
    public static T[] ToManaged<T>(this Il2CppStructArray<T> il2Cpp) where T : unmanaged
        => il2Cpp.AsSpan().ToArray();

    public static T[] ToManaged<T>(this Il2CppReferenceArray<T> il2Cpp) where T : Il2CppObjectBase
    {
        var array = new T[il2Cpp.Length];
        il2Cpp.CopyTo(array, 0);
        return array;
    }

    public static Il2CppStructArray<T> FastIl2CppCopy<T>(this T[] array) where T : unmanaged
    {
        var il2Cpp = new Il2CppStructArray<T>(array.Length);
        array.CopyTo(il2Cpp.AsSpan());
        return il2Cpp;
    }
}