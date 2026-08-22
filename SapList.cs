using System.Collections;

namespace SapList;

public class SapList<T> : IList<T>
{
    private readonly List<T> _list;

    public SapList()
    {
        _list = new List<T>();
    }

    public SapList(int capacity)
    {
        _list = new List<T>(capacity);
    }

    public void RemoveAt(int index)
    {
        var lastIndex = _list.Count - 1;
        if (index != lastIndex)
        {
            _list[index] = _list[lastIndex];
        }

        _list.RemoveAt(lastIndex);
        SwappedItems?.Invoke(lastIndex, index);
    }

    public void Add(T item) => _list.Add(item);

    public void Clear() => _list.Clear();

    public bool Contains(T item) => _list.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index == -1) return false;
        RemoveAt(index);
        return true;
    }

    public int Count => _list.Capacity;
    public bool IsReadOnly => false;

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int IndexOf(T item) => _list.IndexOf(item);

    public void Insert(int index, T item) => _list.Insert(index, item);

    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    public event Action<int, int>? SwappedItems;
}