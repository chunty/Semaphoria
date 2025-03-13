# Setup

Add Semaphoria to your services:
```
builder.Services.AddSemaphoria();
```

# Usage
Inject the ISemaphoreManager into your class:

```csharp
public class MyClass(ISemaphoreManager semaphoreManager)
{
		public async Task MyMethod()
	{
		using (var semaphore = _semaphoreManager.GetSemaphore("MyKey"))
		{
			await semaphore.WaitAsync();
			// Do something
		}
	}
})

```

# Extensions

If you want to skip processing rather than wait you can use the `IsFull()` method:

```csharp
var semaphore = _semaphoreManager.GetSemaphore("MyKey")

if (semaphore.IsFull())
{
	// Skip processing
	return;
}

```