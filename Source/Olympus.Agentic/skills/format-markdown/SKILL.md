---
name: format-markdown
description: Validates and formats Markdown files against RULE_Markdown.md and RULE_Document.md standards. Use when preparing documentation for review or ensuring compliance with project formatting rules.
metadata:
  author: Cahya Ong
  version: 1.0
  display-name: Format Markdown
  keywords: [format, validate, markdown, documentation, table, heading]
  example-prompt:
    - Format IDEA_MenuService.md
    - Validate the Markdown in SNIPPET_OrderProcessing.md
    - Check if RULE_KitchenWorkflow.md follows documentation standards
---

# SKILL: Format Markdown

**Last Updated:** February 5, 2026

---

## Table of Contents

- [SKILL: Format Markdown](#skill-format-markdown)
  - [Table of Contents](#table-of-contents)
  - [1. Overview](#1-overview)
  - [2. Execution Workflow](#2-execution-workflow)
  - [3. Best Practices](#3-best-practices)
    - [3.1 Large File Processing](#31-large-file-processing)
    - [3.2 Table Validation](#32-table-validation)
  - [4. Self-Assessment Protocol](#4-self-assessment-protocol)
  - [5. Variable Reference](#5-variable-reference)

---

## 1. Overview

Validates Markdown files against [RULE_Markdown.md](../../rules/RULE_Markdown.md) (formatting) and [RULE_Document.md](../../rules/RULE_Document.md) (content).

**Use when:** Preparing, creating, or updating Markdown documentation.

**Do NOT use when:** File is not Markdown format, or only reading without intent to modify.

## 2. Execution Workflow

**Step 1: Load Rules**
1. Read [RULE_Markdown.md](../../rules/RULE_Markdown.md) for formatting standards
2. Read [RULE_Document.md](../../rules/RULE_Document.md) for content rules

**Step 2: Analyze Target File**
1. Read target Markdown file
2. Detect file type by prefix (SNIPPET, IDEA, SKILL, RULE, AUDIT, SUMMARY)

**Step 3: Validate by Priority**
1. 🚨 CRITICAL: Heading numbering, TOC, Last Updated date
2. ❌ HIGH: Path notation, code snippets, table column alignment
3. ⚠️ MEDIUM: Emoji usage, date format

**Step 4: Check File-Specific Rules**
1. SNIPPET: Section alignment with corresponding IDEA file
2. IDEA: No language/framework specifics
3. SKILL: YAML metadata present
4. RULE/SKILL: Restaurant app examples

**Step 5: Apply Fixes**
1. Fix identified issues
2. Update Last Updated date only if content changed

**Step 6: Self-Verify**
1. Run self-assessment checklist (Section 4)
2. Verify all changes applied correctly

**Output (File):** Edited target file (template: none)
**Output (Console):** Validation summary (template: assets/TEMPLATE_Summary_SelfAssessment.md)

## 3. Best Practices

### 3.1 Large File Processing

For files ≥1,000 lines, use batch processing:

**Per Batch:**
1. Process 3-5 H2 sections at a time
2. Report progress: "Batch X of Y (Sections M-N)"
3. On failure: Reduce to 1-2 sections, retry

**Completion:** Final full-file verification before presenting results.

### 3.2 Table Validation

**Algorithm:**
1. **Count** longest cell content per column (include ALL characters)
2. **Calculate** column width as max content length plus 2 (one space padding each side)
3. **Set** separator dashes equal to column width exactly
4. **Pad** all cells to column width with trailing spaces

**🚨 Post-Fix Verification:** Re-read file, re-count columns after every change.

## 4. Self-Assessment Protocol

**🚨 CRITICAL:** Before presenting results, verify:

- [ ] Re-read modified file after changes
- [ ] All changes applied correctly
- [ ] Last Updated: Updated only if content changed
- [ ] TOC: Present with all H2/H3 anchor links
- [ ] Heading numbers sequential (H2: 1, 2, 3; H3: 1.1, 1.2)
- [ ] Table column width equals longest content plus 2 spaces padding
- [ ] Separator dashes match column width exactly
- [ ] No emojis in table headers or cells
- [ ] Emojis followed by UPPERCASE text

## 5. Variable Reference

| Variable           | Description                  | Example                   |
|--------------------|------------------------------|---------------------------|
| `{filename}`       | Name of the validated file   | `IDEA_MenuService.md`     |
| `{file_type}`      | Document type prefix         | `IDEA`                    |
| `{line_number}`    | Line number of issue         | `42`                      |
| `{description}`    | Issue description            | `Column width mismatch`   |
| `{current_state}`  | Current problematic content  | `❌ wrong`                |
| `{required_state}` | Required correct format      | `❌ WRONG`                |
