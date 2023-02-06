# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id":              "00000000-0000-0000-0000-000000000000",
  "name":            "My Menu",
  "description":     "This is my menu",
  "averageRating":   4.5,
  "sections":        [
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Appetizers",
    "description": "These are my appetizers",
    "items": [
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "My Appetizer",
      "description": "This is my appetizer",
      "price": 10.00
    ]
  ],
  "createdDateTime": "2019-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2019-01-01T00:00:00.0000000Z",
  "hostId":          "00000000-0000-0000-0000-000000000000",
  "dinnerIds":       [
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000"
  ],
  "menuReviewIds":   [
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000"
  ]
}
```
