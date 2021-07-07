# Singleton-Pattern-practice

example

```C#
public class TestManager : DesignPattern.Singleton<TestManager>
{
    protected TestManager() { }
    public void Show() => Debug.Log("Hello world");
}
```

```C#
public class A : MonoBehaviour
{
    void Start()
    {
        TestManager.Instance.Show();
    }
}
```
