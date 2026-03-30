# SUMMARY: Toolbox

**Last Updated:** February 10, 2026

---

## Table of Contents

- [SUMMARY: Toolbox](#summary-toolbox)
  - [Table of Contents](#table-of-contents)
  - [1. Overview](#1-overview)
  - [2. Folder Structure](#2-folder-structure)
  - [3. Rules](#3-rules)
    - [3.1 C# Coding](#31-c-coding)
    - [3.2 Document Content](#32-document-content)
    - [3.3 Markdown Formatting](#33-markdown-formatting)
    - [3.4 Expert Persona](#34-expert-persona)
  - [4. Skills](#4-skills)
    - [4.1 Audit Codebase](#41-audit-codebase)
    - [4.2 Create Skill](#42-create-skill)
    - [4.3 Format Markdown](#43-format-markdown)
    - [4.4 Review Markdown](#44-review-markdown)
  - [5. Cross-References](#5-cross-references)

---

## 1. Overview

The Olympus.Agentic toolbox provides reusable rules and executable skills for AI agent interactions. Rules define coding and documentation standards; skills define repeatable workflows that agents execute consistently.

## 2. Folder Structure

```
Olympus.Agentic/
├── SUMMARY_Toolbox.md
├── rules/
│   ├── RULE_CSharp.md
│   ├── RULE_Document.md
│   ├── RULE_Markdown.md
│   └── RULE_Persona.md
└── skills/
    ├── audit-codebase/
    │   └── SKILL.md
    ├── create-skill/
    │   ├── SKILL.md
    │   └── assets/TEMPLATE_Skill.md
    ├── format-markdown/
    │   ├── SKILL.md
    │   └── assets/TEMPLATE_Summary_SelfAssessment.md
    └── review-markdown/
        └── SKILL.md
```

## 3. Rules

### 3.1 C# Coding

| Aspect               | Key Standards                                                          |
|----------------------|------------------------------------------------------------------------|
| **File**             | `rules/RULE_CSharp.md`                                                 |
| **Scope**            | Production code (`Source/`) and SNIPPET documentation (`.ai-context/`) |
| **Naming**           | `_camelCase` private fields, PascalCase public members                 |
| **Access Modifiers** | Always explicit, never implicit                                        |
| **Control Flow**     | Mandatory braces, empty lines before/after blocks                      |
| **LINQ Chaining**    | Split to multiple lines when 2+ methods in chain                       |
| **SNIPPET Rules**    | Omit copyright, using, namespace, obvious constructors, logging        |

### 3.2 Document Content

| Aspect            | Key Standards                                                                              |
|-------------------|--------------------------------------------------------------------------------------------|
| **File**          | `rules/RULE_Document.md`                                                                   |
| **Scope**         | All document types (IDEA, SNIPPET, AUDIT, SUMMARY, SKILL, RULE, TEMPLATE)                 |
| **H1 Format**     | `[TYPE]: [Topic]` (e.g., `# IDEA: Pathfinding`)                                           |
| **Restrictions**  | No priority markers, effort estimation, timelines, or status tracking (except ROADMAP)     |
| **SNIPPET Rules** | Section numbers must align 1:1 with corresponding IDEA file                                |
| **IDEA Rules**    | Language-agnostic only; no C#, .NET, or framework-specific terms                           |
| **SKILL Rules**   | YAML frontmatter required with name (kebab-case), description, and metadata                |
| **Example Rule**  | RULE and SKILL files must use Restaurant application examples                              |

### 3.3 Markdown Formatting

| Aspect           | Key Standards                                                          |
|------------------|------------------------------------------------------------------------|
| **File**         | `rules/RULE_Markdown.md`                                               |
| **Last Updated** | `**Last Updated:** Month DD, YYYY` format required                     |
| **TOC**          | Required in all Markdown files, includes all H2/H3 with anchor links  |
| **Headings**     | H2 sequential (1, 2, 3), H3 relative (1.1, 1.2), H4 unnumbered      |
| **Tables**       | Column width = longest content + 2 spaces padding; no emojis in tables |
| **Emojis**       | Must be followed by UPPERCASE text                                     |
| **Severity**     | CRITICAL, HIGH, MEDIUM, LOW                                            |

### 3.4 Expert Persona

| Aspect         | Key Standards                                                                                |
|----------------|----------------------------------------------------------------------------------------------|
| **File**       | `rules/RULE_Persona.md`                                                                      |
| **Scope**      | Reusable expert personas for audits, analysis, and technical evaluations                     |
| **Categories** | General Software (8), Game Development (5), Documentation (2), Research (2) — 17 total       |
| **Usage**      | State role explicitly, use persona-appropriate terminology, focus on primary concerns         |
| **Selection**  | Match persona to problem type (code quality → Software Engineer, security → Security Engineer) |

## 4. Skills

### 4.1 Audit Codebase

| Aspect       | Details                                                                          |
|--------------|----------------------------------------------------------------------------------|
| **File**     | `skills/audit-codebase/SKILL.md`                                                 |
| **Purpose**  | Conducts codebase audits using expert personas, generates `AUDIT_*.md` reports   |
| **Input**    | Audit type selection (Code Quality, Architecture, Security, Performance, etc.)   |
| **Output**   | `.ai-context/AUDIT_{audit_type}.md` with grade (A-F), findings, recommendations |
| **Workflow** | Select audit type → Analyze codebase → Generate report → Validate               |

### 4.2 Create Skill

| Aspect       | Details                                                                  |
|--------------|--------------------------------------------------------------------------|
| **File**     | `skills/create-skill/SKILL.md`                                           |
| **Purpose**  | Guides creation of new SKILL files per the agentskills.io specification  |
| **Input**    | Task description, name, intended audience                                |
| **Output**   | `skills/{skill_name}/SKILL.md` using `assets/TEMPLATE_Skill.md`         |
| **Workflow** | Gather requirements → Define metadata → Write content → Optimize         |

### 4.3 Format Markdown

| Aspect       | Details                                                                            |
|--------------|------------------------------------------------------------------------------------|
| **File**     | `skills/format-markdown/SKILL.md`                                                  |
| **Purpose**  | Validates and formats Markdown files against RULE_Markdown.md and RULE_Document.md |
| **Input**    | Target Markdown file                                                               |
| **Output**   | Edited target file + console validation summary                                    |
| **Workflow** | Load rules → Analyze file → Validate by priority → Check file-specific rules       |

### 4.4 Review Markdown

| Aspect       | Details                                                                           |
|--------------|-----------------------------------------------------------------------------------|
| **File**     | `skills/review-markdown/SKILL.md`                                                  |
| **Purpose**  | Optimizes Markdown documentation for conciseness and clarity, reduces token usage  |
| **Input**    | Target Markdown file                                                              |
| **Output**   | Edited target file + reduction metrics                                            |
| **Tiers**    | Aggressive (50-70% for toolbox/AGENTS), Balanced (30-50% for `.ai-context/`)      |
| **Workflow** | Analyze document → Plan optimization → Apply changes → Validate                   |

## 5. Cross-References

| From                              | References                                                       |
|-----------------------------------|------------------------------------------------------------------|
| `rules/RULE_CSharp.md`           | `RULE_Markdown.md` Section 6 (severity levels)                    |
| `rules/RULE_Document.md`         | `RULE_Markdown.md` (formatting), `RULE_CSharp.md` (code)         |
| `rules/RULE_Persona.md`          | `RULE_Markdown.md` Section 6 (severity levels)                    |
| `skills/audit-codebase/SKILL.md` | `RULE_Persona.md`, `RULE_Markdown.md` Section 6                  |
| `skills/create-skill/SKILL.md`   | `RULE_Document.md`, agentskills.io specification                  |
| `skills/format-markdown/SKILL.md` | `RULE_Markdown.md`, `RULE_Document.md`                           |
| `skills/review-markdown/SKILL.md` | `RULE_Persona.md`, `format-markdown` skill                       |
