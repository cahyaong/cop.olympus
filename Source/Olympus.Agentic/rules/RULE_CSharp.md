# RULE: C# Coding

**Last Updated:** February 10, 2026

---

## Table of Contents

- [RULE: C# Coding](#rule-c-coding)
  - [Table of Contents](#table-of-contents)
  - [1. Overview](#1-overview)
  - [2. Naming Conventions](#2-naming-conventions)
  - [3. Code Organization](#3-code-organization)
    - [3.1 File Structure](#31-file-structure)
    - [3.2 Member Ordering](#32-member-ordering)
    - [3.3 Access Modifiers](#33-access-modifiers)
    - [3.4 Member Access](#34-member-access)
  - [4. Control Flow](#4-control-flow)
    - [4.1 Mandatory Braces](#41-mandatory-braces)
    - [4.2 Empty Lines](#42-empty-lines)
    - [4.3 Brace Placement](#43-brace-placement)
    - [4.4 LINQ and Method Chaining](#44-linq-and-method-chaining)
    - [4.5 Boolean Operations](#45-boolean-operations)
  - [5. Production Code Requirements](#5-production-code-requirements)
    - [5.1 Mandatory Elements](#51-mandatory-elements)
    - [5.2 Error Handling](#52-error-handling)
  - [6. Documentation Code Standards](#6-documentation-code-standards)
    - [6.1 Purpose](#61-purpose)
    - [6.2 Exclusions](#62-exclusions)
    - [6.3 Constructor Rule](#63-constructor-rule)
    - [6.4 Initialization Formatting](#64-initialization-formatting)
  - [7. Self-Assessment Protocol](#7-self-assessment-protocol)

---

C# standards for production code (`Source/`) and SNIPPET documentation (`.ai-context/SNIPPET_*.md`). For severity levels, see `RULE_Markdown.md` Section 6.

## 1. Overview

| Context         | Location                   | Purpose                                    |
|-----------------|----------------------------|--------------------------------------------|
| Production Code | `Source/`                  | Compilable, complete implementations       |
| SNIPPET Code    | `.ai-context/SNIPPET_*.md` | Illustrative pseudo-code for architecture  |
| AUDIT Code      | `.ai-context/AUDIT_*.md`   | Illustrative fixes in audit reports        |

**Key Difference:** Production requires full boilerplate; SNIPPET and AUDIT omit it for readability.

## 2. Naming Conventions

| Element                    | Convention                 | Example          |
|----------------------------|----------------------------|------------------|
| Private instance fields    | `_camelCase`               | `_orderManager`  |
| Static fields (any access) | PascalCase (no underscore) | `GlobalCounter`  |
| Public properties          | PascalCase                 | `CustomerName`   |
| Methods                    | PascalCase                 | `ProcessOrder()` |
| Local variables            | camelCase                  | `orderCount`     |
| Constants                  | PascalCase                 | `MaxRetries`     |
| Interfaces                 | IPascalCase                | `IOrderService`  |
| Type parameters            | T or TPascalCase           | `TMenuItem`      |

**🚨 CRITICAL:** Descriptive variable names required. No abbreviations or single letters.

```csharp
// ❌ WRONG
var o = GetOrder();
var temp = Calculate();
for (int i = 0; i < count; i++) { }  // Wrong in SNIPPET

// ✅ CORRECT
var selectedOrder = GetOrder();
var temporaryValue = Calculate();
for (int orderIndex = 0; orderIndex < count; orderIndex++) { }
```

**Note:** Simple loop counters (`i`, `j`) acceptable in Production Code only, never in SNIPPET.

## 3. Code Organization

### 3.1 File Structure

- Namespace MUST match folder hierarchy
- One class per file
- Filename matches class name

### 3.2 Member Ordering

1. Fields (public → protected → private)
2. Constructors (static, then instance)
3. Properties (public → protected → private)
4. Methods (public → protected → private)

### 3.3 Access Modifiers

**🚨 CRITICAL:** Always explicit, never implicit.

```csharp
// ❌ WRONG
int _count;
void Process() { }

// ✅ CORRECT
private int _count;
private void Process() { }
```

### 3.4 Member Access

Use explicit qualifiers:

| Member Type | Prefix     | Example                      |
|-------------|------------|------------------------------|
| Instance    | `this.`    | `this._repository.Save()`    |
| Static      | Class name | `OrderService.GlobalCount++` |

## 4. Control Flow

### 4.1 Mandatory Braces

**🚨 CRITICAL:** ALL control flow MUST use curly braces.

```csharp
// ❌ WRONG
if (isValid)
    Process();

// ✅ CORRECT
if (isValid)
{
    Process();
}
```

### 4.2 Empty Lines

**❌ HIGH:** Empty line BEFORE and AFTER all control flow blocks.

```csharp
var order = GetOrder();

if (order.IsValid)
{
    ProcessOrder(order);
}

SendConfirmation();
```

**Exception:** No empty lines within `if-else if-else` chains.

### 4.3 Brace Placement

| Structure                      | Brace Position |
|--------------------------------|----------------|
| Classes, methods, control flow | New line       |
| Property accessors             | Same line      |
| Object/collection initializers | Same line      |
| Single-line lambdas            | Same line      |

```csharp
// New line for classes/methods/control flow
public class OrderService
{
    public void Process()
    {
        if (condition)
        {
        }
    }
}

// Same line for properties
public int Count { get; set; }
```

### 4.4 LINQ and Method Chaining

**Split threshold:** Split to multiple lines when **2+ methods** in chain.

| Rule                  | Description                                          |
|-----------------------|------------------------------------------------------|
| Line-per-method       | Each chained method on its own line                  |
| First dot on new line | First method starts on new line after variable/type  |
| 4-space indent        | Chained methods indented 4 spaces from starting line |
| Nested chains         | Additional 4-space indent for chains inside lambdas  |

```csharp
// ❌ WRONG - multiple methods on one line
var pendingOrders = orders.Where(order => order.IsPending).OrderBy(order => order.TableNumber).ToList();

// ✅ CORRECT - split when 2+ methods
var pendingOrders = orders
    .Where(order => order.IsPending)
    .OrderBy(order => order.TableNumber)
    .ToList();

// ✅ CORRECT - static method call, chained methods below
Enumerable
    .Range(0, restaurantTableCount)
    .Select(index => CreateRestaurantTable(index))
    .ForEach(PrepareTable);

// ✅ CORRECT - lambda with object initializer (nested chains use additional indent)
orders
    .Select(order => new OrderSummary
    {
        TableNumber = order.TableNumber,
        TotalAmount = order.CalculateTotal()
    })
    .ForEach(summary => SendReceipt(summary));
```

### 4.5 Boolean Operations

**Extract complex conditions** to descriptive variables. First comparison on new line.

| Rule                         | Description                                                   |
|------------------------------|---------------------------------------------------------------|
| Extract to variable          | Complex boolean conditions extracted to descriptive variable  |
| First comparison on new line | Starts on new line after assignment operator                  |
| Operator at line end         | `&&` or `\|\|` placed at end of line when splitting           |
| 4-space indent               | Continuation lines indented 4 spaces                          |

```csharp
// ❌ WRONG - complex condition directly in if statement
if (order.IsPaid && order.HasBeenServed && order.Rating > 3)
{
}

// ✅ CORRECT - extract to variable, each comparison on new line
var shouldSendFeedbackRequest =
    order.IsPaid &&
    order.HasBeenServed &&
    order.Rating > 3;

if (shouldSendFeedbackRequest)
{
}

// ✅ CORRECT - multiple conditions with OR
var canAcceptNewReservation =
    !restaurant.IsClosed &&
    (availableTables > 0 ||
    expectedDeparturesWithinHour > 0);

if (canAcceptNewReservation)
{
}
```

## 5. Production Code Requirements

### 5.1 Mandatory Elements

**Copyright Header:**
```csharp
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileName.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Day, Month DD, YYYY HH:MM:SS AM/PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------
```

**Also required:** Using statements, namespace declaration, complete implementations.

### 5.2 Error Handling

- Input validation at public API boundaries
- Try-catch for external operations
- Custom exceptions for domain errors
- Descriptive error messages

## 6. Documentation Code Standards

Applies to SNIPPET (`.ai-context/SNIPPET_*.md`) and AUDIT (`.ai-context/AUDIT_*.md`) files.

### 6.1 Purpose

Illustrate architecture without compilation overhead. Focus on patterns over boilerplate.

### 6.2 Exclusions

**OMIT from SNIPPET and AUDIT files:**
- Copyright headers, XML docs
- Using statements, namespaces
- Obvious constructors (param→field only)
- Implementation comments if obvious
- Logging declarations (`ILogger`, `_logger` fields)
- Logging calls (`LogInformation`, `LogWarning`, `LogError`, etc.)

### 6.3 Constructor Rule

**Omit** obvious constructors:
```csharp
// ❌ WRONG in SNIPPET
public class OrderService
{
    private readonly IRepository _repository;
    
    public OrderService(IRepository repository)
    {
        _repository = repository;
    }
}

// ✅ CORRECT in SNIPPET
public class OrderService
{
    private readonly IRepository _repository;
    
    public void ProcessOrder() { }
}
```

**Keep** constructors with validation or complex logic.

### 6.4 Initialization Formatting

**Simple type initialization MUST be on a single line** in SNIPPET and AUDIT files. Applies to primitives (`int`, `float`, `bool`, `string`), single-value objects, and empty collections.

**Complex initializations MAY span multiple lines** when they include collections with multiple entries (dictionaries, arrays, lists), object initializers with multiple properties, or nested structures.

```csharp
// ✅ CORRECT - simple types on one line
private readonly int _maxTableCapacity = 50;
private readonly string _defaultChefName = "Unknown";
private readonly List<Order> _pendingOrders = new List<Order>();
private readonly Random _random = new Random();

// ✅ CORRECT - complex types may span lines
private readonly Dictionary<string, decimal> _menuPrices = new()
{
    ["Appetizer"] = 8.50m,
    ["MainCourse"] = 24.99m,
    ["Dessert"] = 7.50m
};
```

## 7. Self-Assessment Protocol

**🚨 CRITICAL:** Before presenting results, verify using this checklist:

**Both Contexts:**
- [ ] Private instance fields use `_camelCase`
- [ ] Static fields use PascalCase (no underscore)
- [ ] Access modifiers explicit
- [ ] Instance members use `this.` prefix
- [ ] Static members use class name prefix
- [ ] Control flow has curly braces
- [ ] Empty lines around control flow blocks
- [ ] Brace on new line for classes/methods/control flow
- [ ] LINQ chains with 2+ methods split to multiple lines
- [ ] Complex boolean conditions extracted to named variables

**Production Code Only:**
- [ ] Copyright header present
- [ ] Using statements and namespace
- [ ] Complete implementations (no TODOs)
- [ ] Error handling implemented
- [ ] File name matches class name

**Documentation Code Only (SNIPPET/AUDIT):**
- [ ] No copyright, using, namespace
- [ ] Obvious constructors omitted
- [ ] Variable names descriptive (no `i`, `temp`)
- [ ] Field/property initialization on single line
- [ ] Focused on architecture/patterns
- [ ] No logging declarations (`ILogger`, `_logger`)
- [ ] No logging calls (`LogInformation`, `LogWarning`, `LogError`)
