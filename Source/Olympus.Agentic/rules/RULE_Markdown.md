# RULE: Markdown Formatting

**Last Updated:** February 5, 2026

---

## Table of Contents

- [RULE: Markdown Formatting](#rule-markdown-formatting)
  - [Table of Contents](#table-of-contents)
  - [1. Core Requirements](#1-core-requirements)
    - [1.1 Last Updated Date](#11-last-updated-date)
    - [1.2 Table of Contents](#12-table-of-contents)
  - [2. Heading Structure](#2-heading-structure)
    - [2.1 Numbering Convention](#21-numbering-convention)
    - [2.2 Label Conventions](#22-label-conventions)
  - [3. Path Notation](#3-path-notation)
  - [4. Content Formatting](#4-content-formatting)
    - [4.1 Code Snippets](#41-code-snippets)
    - [4.2 Lists](#42-lists)
    - [4.3 Tables](#43-tables)
    - [4.4 Variables](#44-variables)
  - [5. Emoji Standards](#5-emoji-standards)
    - [5.1 Boolean Operations](#51-boolean-operations)
    - [5.2 Severity Levels](#52-severity-levels)
    - [5.3 Status Indicators](#53-status-indicators)
  - [6. Severity Levels](#6-severity-levels)
  - [7. Self-Assessment Protocol](#7-self-assessment-protocol)

---

This document defines Markdown formatting standards. For content rules (IDEA, SNIPPET, SKILL), see `RULE_Document.md`.

## 1. Core Requirements

### 1.1 Last Updated Date

**Format:** `**Last Updated:** Month DD, YYYY` (after main title)

- ✅ CORRECT: `**Last Updated:** December 21, 2025`
- ❌ WRONG: `12/21/2025` or `Dec 21, 2025`

**Update only when content changes** - not for validation-only passes.

### 1.2 Table of Contents

**Required in ALL Markdown files.** Place after Last Updated, between `---` dividers.

```markdown
---

## Table of Contents

- [1. Section](#1-section)
  - [1.1 Subsection](#11-subsection)
- [2. Next Section](#2-next-section)

---
```

**Rules:**
- Include all H2 and H3 sections with anchor links
- Two-space indentation for H3 subsections
- H4+ NOT included in TOC

**Anchor format:** Lowercase, spaces→hyphens, keep numbers/periods, remove special chars.

| Heading                   | Anchor                |
|---------------------------|-----------------------|
| `## 1. Order Management`  | `#1-order-management` |
| `### 2.1 Menu Repository` | `#21-menu-repository` |

## 2. Heading Structure

### 2.1 Numbering Convention

| Level | Format             | Example                                |
|-------|--------------------|-----------------------------------------|
| H2    | Sequential from 1  | `## 1. Section`, `## 2. Next`           |
| H3    | Relative to parent | `### 1.1 Sub`, `### 1.2 Another`        |
| H4    | Unnumbered         | `#### Details`                          |
| H5+   | Don't use          | Use `- **Title:** Content` instead      |

**Sequential integrity:** Renumber all affected sections when adding/removing/moving.

### 2.2 Label Conventions

Use natural language, not code identifiers.

- ❌ WRONG: `### Adding _tableNumber Property`
- ✅ CORRECT: `### Adding Table Number Property`

## 3. Path Notation

| Type    | Rule            | Example                          |
|---------|-----------------|----------------------------------|
| Folders | Trailing `/`    | `src/Restaurant.API/`            |
| Files   | No trailing `/` | `src/Restaurant.Domain/Order.cs` |

## 4. Content Formatting

### 4.1 Code Snippets

Show complete code OR explain omissions in prose.

- ❌ WRONG: `// ... existing code`
- ✅ CORRECT: Full code or prose explanation

### 4.2 Lists

Use lists for 3+ items (not comma-separated sentences).

- ❌ WRONG: "Files include A.cs, B.cs, and C.cs"
- ✅ CORRECT: Bulleted list

### 4.3 Tables

**Rules:**
1. Column width equals longest cell content in that column plus exactly two spaces (one padding on each side)
2. Shorter cells pad with spaces to match column width for vertical alignment
3. Separator dashes match column width exactly
4. No emojis in tables (headers or cells) - use text alternatives

**Exception:** `RULE_Markdown.md` may use emojis in tables to document emoji standards.

**Padding Example:**

❌ WRONG (no padding or inconsistent padding):
```markdown
| Name | Status |
|---|---|
| OrderService | Active |
```

✅ CORRECT (aligned columns, one space padding around longest content):
```markdown
| Name         | Status |
|--------------|--------|
| OrderService | Active |
| MenuService  | Paused |
```

In this example:
- Column 1: "OrderService" (12 chars) is longest → column width = 14 (12 + 2 padding)
- Column 2: "Status" (6 chars) is longest → column width = 8 (6 + 2 padding)
- "MenuService" and "Active"/"Paused" get extra trailing spaces to align

**Rationale:** Emojis cause column misalignment due to inconsistent character widths across viewers.

### 4.4 Variables

**Use `{snake_case}` syntax** for placeholders in templates and documentation.

- ✅ CORRECT: `{skill_name}`, `{file_type}`, `{audit_type}`
- ❌ WRONG: `[Type]`, `<variable>`, `VARIABLE`

**Rules:**
- Wrap variable names in curly braces: `{variable_name}`
- Use snake_case inside braces: `{skill_name}`, not `{skillName}`
- Wrap in backticks when shown inline: `` `{variable_name}` ``

## 5. Emoji Standards

**Rule:** Emojis MUST be followed by UPPERCASE text.

### 5.1 Boolean Operations

| Usage         | Format                   |
|---------------|--------------------------|
| Correct/Wrong | `✅ CORRECT` / `❌ WRONG` |
| Yes/No        | `✅ YES` / `❌ NO`        |

### 5.2 Severity Levels

See [Section 6](#6-severity-levels) for definitions.

### 5.3 Status Indicators

| Status      | Emoji          | Meaning                                     |
|-------------|----------------|---------------------------------------------|
| Completed   | 🟢 COMPLETED   | Fully implemented, tested, production-ready |
| In Progress | 🟠 IN PROGRESS | Actively being developed                    |
| In Planning | 🟣 IN PLANNING | Designed, ready for implementation          |
| Not Started | 🔴 NOT STARTED | Not yet begun                               |

## 6. Severity Levels

**Canonical definitions** - referenced by all RULE and SKILL files.

| Level    | Emoji | Use For                                                                     |
|----------|-------|-----------------------------------------------------------------------------|
| CRITICAL | 🚨    | Production blockers, security vulnerabilities, data corruption              |
| HIGH     | ❌    | Major performance issues, architecture violations, maintainability problems |
| MEDIUM   | ⚠️    | Code quality issues, minor performance problems, inconsistencies            |
| LOW      | ℹ️    | Style issues, documentation gaps, minor improvements                        |

## 7. Self-Assessment Protocol

**🚨 CRITICAL:** Before presenting results, verify using this checklist:

**Core Requirements:**
- [ ] Last Updated date present (`Month DD, YYYY`)
- [ ] Table of Contents after Last Updated, between `---`
- [ ] TOC includes all H2/H3 with anchor links

**Structure and Content:**
- [ ] H2 numbered sequentially (1, 2, 3...)
- [ ] H3 numbered relative to parent (1.1, 1.2...)
- [ ] H4 unnumbered; no H5+
- [ ] Folders end with `/`; files don't
- [ ] Emojis followed by UPPERCASE
- [ ] Code complete or explained in prose
- [ ] Headings use natural language
- [ ] 3+ items use lists

**Tables:**
- [ ] Table columns aligned (width = longest content + 2 spaces padding)
- [ ] Table separator dashes match column width
- [ ] Tables contain no emojis (headers or cells)

**Variables:**
- [ ] Placeholders use `{snake_case}` syntax

**Validation Tools:**
- [ ] No emoji violations (regex: `(?:✅|❌|🚨|⚠️|ℹ️|🟢|🟠|🟣|🔴)\s+[a-z]`)
