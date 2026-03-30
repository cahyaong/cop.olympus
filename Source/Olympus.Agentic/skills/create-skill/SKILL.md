---
name: create-skill
description: Guides creation of SKILL files for AI agent interactions following the agentskills.io specification. Use when defining repeatable tasks that agents should execute consistently.
metadata:
  author: Cahya Ong
  version: 1.0
  display-name: Create Skill
  keywords: [skill, create, template, agent, documentation, automation]
  example-prompt:
    - Help me create a new skill for validating order data
    - Can you guide me through creating a SKILL file for menu management?
    - I want to create a skill that audits kitchen inventory
---

# SKILL: Create Skill

**Last Updated:** February 10, 2026

---

## Table of Contents

- [SKILL: Create Skill](#skill-create-skill)
  - [Table of Contents](#table-of-contents)
  - [1. Overview](#1-overview)
  - [2. Required Components](#2-required-components)
    - [2.1 YAML Frontmatter](#21-yaml-frontmatter)
    - [2.2 Document Structure](#22-document-structure)
    - [2.3 Optional Directories](#23-optional-directories)
  - [3. Execution Workflow](#3-execution-workflow)
  - [4. Best Practices](#4-best-practices)
  - [5. Self-Assessment Protocol](#5-self-assessment-protocol)
  - [6. Variable Reference](#6-variable-reference)

---

## 1. Overview

Guides creation of SKILL files per the [agentskills.io specification](https://agentskills.io/specification). A SKILL file defines a repeatable task for AI agents: YAML frontmatter (metadata), body content (instructions), and optional directories (scripts, references, assets).

**Use when:** Task is repeatable, multiple users benefit, requires domain knowledge, output should be standardized.

**Do NOT use when:** One-time task, existing skills cover it, task too simple, no structured output needed.

## 2. Required Components

### 2.1 YAML Frontmatter

**🚨 CRITICAL:** Must comply with agentskills.io specification.

| Field           | Required | Constraints                                                                      |
|-----------------|----------|----------------------------------------------------------------------------------|
| `name`          | Yes      | 1-64 chars, lowercase `a-z`, numbers, hyphens. No `--`, no leading/trailing `-`  |
| `description`   | Yes      | 1-1024 chars. What it does AND when to use it.                                   |
| `license`       | No       | License name or bundled file reference                                           |
| `compatibility` | No       | Environment requirements (max 500 chars)                                         |
| `metadata`      | No       | Custom key-value fields (author, version, keywords, etc.)                        |

**Name Rules:** Must start with verb (validate, process, analyze, create, review), match parent directory name.

**Example:**

```yaml
---
name: validate-order
description: Validates restaurant order data against menu and inventory constraints. Use when processing customer orders.
metadata:
  author: example-org
  version: 1.0
  display-name: Validate Order
  keywords: [order, validate, menu]
  example-prompt:
    - Validate the order data in OrderController.cs
---
```

### 2.2 Document Structure

| Section              | Required | Purpose                            |
|----------------------|----------|------------------------------------|
| YAML Frontmatter     | Yes      | Discovery metadata                 |
| H1 Title             | Yes      | `# SKILL: {topic_name}`            |
| Last Updated         | Yes      | `**Last Updated:** Month DD, YYYY` |
| TOC                  | Yes      | All H2/H3 sections with anchors    |
| Overview             | Yes      | One-liner intro + what/when        |
| Execution Workflow   | Yes      | Step-by-step process               |
| Self-Assessment      | Yes      | Verification checklist             |
| Output Template      | No       | Expected result format             |

**Keep under 500 lines** per `RULE_Document.md`. Move detailed references to `references/` directory.

### 2.3 Optional Directories

```
Olympus.Agentic/skills/{skill_name}/
├── SKILL.md       # Required
├── scripts/       # Executable code (Python, Bash, JS)
├── references/    # Additional documentation
└── assets/        # Templates, images, data files
```

## 3. Execution Workflow

**Step 1: Gather Requirements**
1. Identify repeatable task to automate
2. List inputs, outputs, decision points
3. Review existing SKILL files for patterns

**Step 2: Define Metadata**
1. Choose `name` (lowercase, hyphens, verb-first, max 64 chars)
2. Write `description` (max 1024 chars, what AND when)
3. Add optional fields under `metadata`

**Step 3: Write Content**
1. Overview section (one-liner intro + purpose)
2. Execution Workflow (4-6 steps)
3. Self-Assessment Protocol with `🚨 CRITICAL` marker

**Step 4: Optimize and Validate**
1. Remove redundant words, use tables for structured data
2. Verify frontmatter complies with spec
3. Confirm under 500 lines

**Step 5: Finalize**
1. Run `format-markdown` skill
2. Verify all changes applied correctly

**Output (File):** `Olympus.Agentic/skills/{skill_name}/SKILL.md` (template: assets/TEMPLATE_Skill.md)

## 4. Best Practices

**Workflow Format:**

| Element     | Format                        | Example                  |
|-------------|-------------------------------|--------------------------|
| Step header | `**Step N: [Verb + Object]**` | `**Step 1: Load Rules**` |
| Step count  | 4-6 steps (optimal)           | Not 3, not 7+            |
| Sub-steps   | Numbered list (1, 2, 3...)    | `1. Read file`           |
| Output      | `**Output (File|Console):**`  | Path + template info     |

**Progressive Disclosure:** Metadata (~100 tokens) loaded at startup, full body (<5000 tokens) when activated, resources loaded on demand.

**Common Mistakes:**

| Mistake                  | Fix                                        |
|--------------------------|--------------------------------------------|
| Invalid name format      | Lowercase, hyphens only, no `--`           |
| Description too vague    | Include what AND when to use               |
| SKILL.md too long        | Move details to `references/`              |
| Non-spec frontmatter     | Use `metadata` for custom fields           |

**Token Optimization:** Use tables over prose, prefer bullets over paragraphs, replace "it/this/that" with specific nouns.

## 5. Self-Assessment Protocol

**🚨 CRITICAL:** Before presenting results, verify:

**Frontmatter:**
- [ ] `name` is 1-64 chars, lowercase, hyphens, starts with verb
- [ ] `name` has no `--`, doesn't start/end with hyphen
- [ ] `description` is 1-1024 chars, explains what AND when
- [ ] Custom fields placed under `metadata`

**Structure:**
- [ ] H1 follows `# SKILL: {topic_name}` format
- [ ] Last Updated date present
- [ ] TOC includes all H2/H3 sections
- [ ] Overview, Execution Workflow, Self-Assessment present

**Quality:**
- [ ] SKILL.md under 500 lines
- [ ] Steps are specific and actionable
- [ ] Run `format-markdown` skill validation
- [ ] No redundant words or filler phrases

## 6. Variable Reference

| Variable              | Description                    | Example                   |
|-----------------------|--------------------------------|---------------------------|
| `{skill_name}`        | Verb-first name (max 64 chars) | `validate-order`          |
| `{skill_description}` | What AND when (max 1024 chars) | `Validates order data...` |
| `{author}`            | Skill author                   | `example-org`             |
| `{version}`           | Semantic version               | `1.0`                     |
| `{display_name}`      | Title case name                | `Validate Order`          |
| `{keyword_n}`         | Keywords (n = 1, 2, 3)         | `order`, `validate`       |
| `{example_prompt_n}`  | Example invocations            | `Validate the order...`   |
| `{topic_name}`        | Title case topic for H1        | `Validate Order`          |
