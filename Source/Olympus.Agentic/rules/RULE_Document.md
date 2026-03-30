# RULE: Document Content

**Last Updated:** February 10, 2026

---

## Table of Contents

- [RULE: Document Content](#rule-document-content)
  - [Table of Contents](#table-of-contents)
  - [1. File Types](#1-file-types)
    - [1.1 H1 Heading Format](#11-h1-heading-format)
    - [1.2 Global Content Restrictions](#12-global-content-restrictions)
  - [2. Example Conventions](#2-example-conventions)
  - [3. SNIPPET Files](#3-snippet-files)
    - [3.1 Section Mapping](#31-section-mapping)
    - [3.2 Code Format](#32-code-format)
    - [3.3 Allowed Content](#33-allowed-content)
    - [3.4 Lifecycle](#34-lifecycle)
  - [4. IDEA Files](#4-idea-files)
    - [4.1 Allowed vs Prohibited](#41-allowed-vs-prohibited)
    - [4.2 Structure](#42-structure)
  - [5. SKILL Files](#5-skill-files)
  - [6. Other File Types](#6-other-file-types)
  - [7. Self-Assessment Protocol](#7-self-assessment-protocol)

---

Content rules for document types. For Markdown formatting and severity levels, see `RULE_Markdown.md`.

## 1. File Types

| Prefix       | Location                             | Purpose                         |
|--------------|--------------------------------------|---------------------------------|
| `IDEA_*`     | `.ai-context/`                       | Feature discussions (WHAT/WHY)  |
| `SNIPPET_*`  | `.ai-context/`                       | Code implementation references  |
| `AUDIT_*`    | `.ai-context/`                       | Assessment reports              |
| `SUMMARY_*`  | `.ai-context/`                       | Quick reference guides          |
| `ROADMAP_*`  | `.ai-context/`                       | Prioritized development plans   |
| `SKILL_*`    | `Olympus.Agentic/`                   | Executable AI agent skills      |
| `RULE_*`     | `Olympus.Agentic/`                   | Formatting and validation rules |
| `TEMPLATE_*` | `Olympus.Agentic/skills/*/assets/`   | Blank document scaffolds        |
| `*.md`       | `.kiro/`                             | Kiro specs and steering docs    |

### 1.1 H1 Heading Format

**Rule:** H1 MUST follow format `[TYPE]: [Topic]` (e.g., `# IDEA: Pathfinding`)

**TOC Self-Reference:** First TOC entry must match H1 anchor exactly.

### 1.2 Global Content Restrictions

**Applies to:** IDEA, SNIPPET, AUDIT, SUMMARY, SKILL, RULE files  
**Does NOT apply to:** ROADMAP files (exempt)

| Prohibited                                 | Rationale                |
|--------------------------------------------|--------------------------|
| Priority markers (P0, P1, Phase 1)         | ROADMAP files only       |
| Effort estimation (story points, hours)    | Project management tools |
| Implementation timelines                   | ROADMAP files only       |
| Status tracking (Not Started, In Progress) | Project management tools |

## 2. Example Conventions

**🚨 CRITICAL:** RULE_* and SKILL_* files MUST use Restaurant application examples.

**Applies to:** `Olympus.Agentic/` files only

| Category | Examples                                             |
|----------|------------------------------------------------------|
| Paths    | `src/Restaurant.API/`, `src/Restaurant.Domain/`      |
| Files    | `OrderController.cs`, `MenuService.cs`               |
| Concepts | Order, Menu, Customer, Table, Reservation, Kitchen   |

## 3. SNIPPET Files

### 3.1 Section Mapping

**🚨 CRITICAL:** SNIPPET sections MUST align 1:1 with corresponding IDEA file.

- Section numbers match exactly (IDEA 2.1 = SNIPPET 2.1)
- Gaps allowed if IDEA section has no code
- Do NOT renumber to close gaps

### 3.2 Code Format

See `RULE_CSharp.md` Section 6 for complete documentation code rules.

| Include                     | Exclude                                 |
|-----------------------------|-----------------------------------------|
| Class/method signatures     | Copyright, using statements, namespaces |
| Essential properties/fields | XML documentation comments              |
| Core logic/algorithms       | Obvious constructors (param→field only) |

### 3.3 Allowed Content

| Content Type                      | Notes                      |
|-----------------------------------|----------------------------|
| Code snippets with context        | Primary content            |
| Cross-references to IDEA sections | For traceability           |
| Integration notes (technical)     | How systems interact       |
| Performance characteristics       | Complexity, memory, timing |

### 3.4 Lifecycle

| State           | Description                                    |
|-----------------|------------------------------------------------|
| Full SNIPPET    | IDEA has no implemented features               |
| Partial SNIPPET | Some IDEA sections implemented, others pending |
| No SNIPPET      | All IDEA features fully implemented            |

**Deletion:** Remove sections/files when corresponding IDEA features are implemented (verify against codebase).

## 4. IDEA Files

Feature discussions describing WHAT and WHY, not HOW. Audience: Engineers with CS fundamentals.

### 4.1 Allowed vs Prohibited

| Allowed (Language-Agnostic)         | Prohibited (Language-Specific)        |
|-------------------------------------|---------------------------------------|
| A*, Dijkstra, genetic algorithms    | C# keywords (class, interface, var)   |
| Array, hash table, quadtree         | .NET libraries (LINQ, YamlDotNet)     |
| O(n), O(log n), complexity analysis | ECS terms (Component, System as code) |
| Processor, module, subsystem        | async/await, Task, IEnumerable        |

### 4.2 Structure

1. **Purpose & Goals** - Problem statement, objectives
2. **Functional Requirements** - Core capabilities
3. **Non-Functional Requirements** - Performance targets
4. **Architecture & Design** - Algorithms, data structures
5. **Dependencies & Constraints** - Prerequisites, limitations

## 5. SKILL Files

**YAML frontmatter required:**

```yaml
---
name: validate-order
description: Validates restaurant order data
metadata:
  display-name: Validate Order
  keywords: [order, validate, menu, customer]
  example-prompt:
    - Validate the order data in OrderController.cs
    - Can you check if this order request is valid?
---
```

| Field                     | Format          | Required |
|---------------------------|-----------------|----------|
| `name`                    | kebab-case      | Yes      |
| `description`             | Full sentence   | Yes      |
| `metadata.display-name`   | Title Case      | Optional |
| `metadata.keywords`       | Lowercase array | Optional |
| `metadata.example-prompt` | 2-3 strings     | Optional |

## 6. Other File Types

| Type     | Audience              | Structure                                                         |
|----------|-----------------------|-------------------------------------------------------------------|
| AUDIT    | Team leads, engineers | Executive Summary → Findings → Recommendations → Readiness        |
| RULE     | AI agents, writers    | Scope → Rules → Examples → Checklist                              |
| SUMMARY  | Engineers             | Tables preferred, max 2 pages, links to detailed docs             |
| ROADMAP  | Project managers      | Overview → Features by Priority (P0-P3) → Timeline → Dependencies |
| TEMPLATE | Skill users           | Placeholder structure, `{variable}` and `*italic*` guidance       |

**AUDIT Findings Format:** Location, Severity (per `RULE_Markdown.md` Section 6), Problem, Impact, Fix

**ROADMAP Exception:** May contain priorities, timelines, status tracking (see `RULE_Markdown.md` Section 5.3).

**TEMPLATE Exception:** No Last Updated date or TOC (generated by format-markdown skill after template is filled).

## 7. Self-Assessment Protocol

**🚨 CRITICAL:** Before presenting results, verify using this checklist:

**Common:**
- [ ] H1 follows `[TYPE]: [Topic]` format
- [ ] TOC first entry matches H1 anchor
- [ ] No prohibited content per Section 1.2 (except ROADMAP)

**SNIPPET Files:**
- [ ] Section numbers match IDEA exactly
- [ ] No boilerplate (copyright, using, namespace)
- [ ] Implemented sections removed (verify against codebase)

**IDEA Files:**
- [ ] No language specifics (C#, .NET)
- [ ] CS concepts and architecture terms only
- [ ] Requirements document structure followed

**SKILL Files:**
- [ ] YAML frontmatter present with `---` dividers
- [ ] All required attributes (name, description, display-name, keywords, example-prompt)
- [ ] `name` in kebab-case
- [ ] `keywords` lowercase array
- [ ] `example-prompt` has 2-3 distinct examples
- [ ] Self-Assessment Protocol section present

**AUDIT Files:**
- [ ] Executive Summary with overall grade
- [ ] Findings include location, severity, problem, impact, fix
- [ ] Recommendations prioritized (Immediate → Long-term)

**SUMMARY Files:**
- [ ] Tables used for primary content presentation
- [ ] Maximum 2 pages length
- [ ] Links to detailed documentation included

**ROADMAP Files:**
- [ ] Overview section present
- [ ] Features organized by priority (P0-P3)
- [ ] Timeline included
- [ ] Dependencies documented

**RULE Files:**
- [ ] All examples use Restaurant application (Section 2)
- [ ] Rules are specific and testable
- [ ] Cross-references to related RULE files included
- [ ] Self-Assessment Protocol section present

**TEMPLATE Files:**
- [ ] No Last Updated date
- [ ] No Table of Contents
- [ ] `{variable}` syntax used for YAML frontmatter placeholders
- [ ] `*Italic instructions*` used for body section guidance
