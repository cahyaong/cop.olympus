---
name: audit-codebase
description: Conducts codebase audits with configurable personas, generates AUDIT_*.md reports with severity ratings and recommendations. Use when assessing code quality, security, performance, or architecture of a project.
metadata:
  author: Cahya Ong
  version: 1.0
  display-name: Audit Codebase
  keywords: [audit, codebase, quality, assessment, security, performance, architecture]
  example-prompt:
    - Audit the Restaurant codebase for code quality issues
    - Can you perform a security audit on src/Restaurant.API/?
    - Run a performance analysis of the OrderService
---

# SKILL: Audit Codebase

**Last Updated:** February 10, 2026

---

## Table of Contents

- [SKILL: Audit Codebase](#skill-audit-codebase)
  - [Table of Contents](#table-of-contents)
  - [1. Overview](#1-overview)
  - [2. Audit Types](#2-audit-types)
  - [3. Execution Workflow](#3-execution-workflow)
  - [4. Report Structure](#4-report-structure)
  - [5. Self-Assessment Protocol](#5-self-assessment-protocol)
  - [6. Historical Tracking](#6-historical-tracking)

---

## 1. Overview

Conducts codebase audits using expert personas from `RULE_Persona.md`. Generates `AUDIT_*.md` reports in `.ai-context/`. For severity levels, see `RULE_Markdown.md` Section 6.

**Use when:** Assessing code quality, security, performance, or architecture.

**Do NOT use when:** Quick code review without formal report, or non-code documentation audit.

## 2. Audit Types

| Category             | Audit Types                                                                                                         |
|----------------------|---------------------------------------------------------------------------------------------------------------------|
| **General Software** | Code Quality, System Architecture, Performance, Security, Asset Management, DevOps Infrastructure, User Experience |
| **Game Development** | Game Design, Level Design, Narrative Design, Audio Design, QA Testing                                               |
| **Documentation**    | Technical Writing, Information Architecture                                                                         |
| **Research**         | ML Research, Data Science                                                                                           |

See `RULE_Persona.md` Section 2 for persona definitions.

## 3. Execution Workflow

**Step 1: Select Audit Type**
1. If not specified, ask user to select from Section 2
2. Confirm persona perspective before proceeding
3. Define scope (full codebase or specific directories)

**Step 2: Analyze Codebase**
1. Recursively scan `Source/` directory
2. High-level analysis: architectural patterns, dependencies, trends
3. Deep-dive analysis: specific issues with file paths, line numbers, code
4. Classify findings by severity per `RULE_Markdown.md` Section 6

**Step 3: Generate Report**
1. Check for existing `AUDIT_{audit_type}.md`, move to Appendix if exists
2. Create new report using structure (Section 4)
3. Include executive summary with grade and key issues

**Step 4: Validate and Save**
1. Run self-assessment protocol (Section 5)
2. Validate with `format-markdown` skill
3. Save to `.ai-context/AUDIT_{audit_type}.md`

**Output (File):** `.ai-context/AUDIT_{audit_type}.md` (template: none)

## 4. Report Structure

| Section                      | Contents                                                               |
|------------------------------|------------------------------------------------------------------------|
| **Header**                   | Title (`# {audit_type} Audit Report`), Project, Date, Reviewer, Scope  |
| **Executive Summary**        | 2-3 sentence assessment, Grade (A-F), Strengths, Issues                |
| **High-Level Analysis**      | Architectural Patterns, System-Wide Trends                             |
| **Detailed Analysis**        | Numbered categories; each issue: path, severity, code, fix             |
| **Priority Recommendations** | Immediate (Sprint), Short-term (2 Weeks), Medium-term (1 Month)        |
| **Production Readiness**     | Status, Required Work estimate, Risk Areas                             |
| **Appendix**                 | Historical Audits (if applicable)                                      |

## 5. Self-Assessment Protocol

**🚨 CRITICAL:** Before presenting results, verify:

- [ ] Executive summary includes overall grade and key issues
- [ ] High-level analysis covers architectural patterns and trends
- [ ] Detailed analysis includes specific file paths and line numbers
- [ ] All severity ratings assigned consistently per `RULE_Markdown.md` Section 6
- [ ] Priority recommendations organized by timeframe
- [ ] Production readiness assessment provided
- [ ] Historical audits moved to Appendix if applicable
- [ ] Each recommendation has specific action description
- [ ] Code examples show both problem and solution
- [ ] Run `format-markdown` skill on generated file
- [ ] Re-read generated file to confirm accuracy

## 6. Historical Tracking

**Archive Format:**
- Section title: `## Appendix: Historical Audits`
- Subsection: `### Audit from [Month DD, YYYY]`
- Order: Latest to oldest

**Guidelines:** Track resolved issues and grade progression, note newly introduced problems, compare metrics over time.
