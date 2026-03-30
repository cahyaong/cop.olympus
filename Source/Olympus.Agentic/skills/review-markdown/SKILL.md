---
name: review-markdown
description: Optimizes Markdown documentation for conciseness and clarity while reducing token usage for AI agent consumption. Use when documentation is too verbose or contains redundant content.
metadata:
  author: Cahya Ong
  version: 1.0
  display-name: Review Markdown
  keywords: [review, optimize, concise, token, markdown, documentation, refactor, streamline]
  example-prompt:
    - Review and optimize RULE_RestaurantCoding.md for token reduction
    - Can you make SKILL_ValidateOrder.md more concise?
    - Reduce redundancy in IDEA_ReservationSystem.md
---

# SKILL: Review Markdown

**Last Updated:** February 10, 2026

---

## Table of Contents

- [SKILL: Review Markdown](#skill-review-markdown)
  - [Table of Contents](#table-of-contents)
  - [1. Overview](#1-overview)
    - [1.1 Persona Usage](#11-persona-usage)
    - [1.2 Optimization Tiers](#12-optimization-tiers)
  - [2. Optimization Techniques](#2-optimization-techniques)
  - [3. Execution Workflow](#3-execution-workflow)
  - [4. SNIPPET Implementation Audit](#4-snippet-implementation-audit)
  - [5. Self-Assessment Protocol](#5-self-assessment-protocol)
  - [6. Report Template](#6-report-template)

---

## 1. Overview

Optimizes Markdown documentation for conciseness and clarity while preserving essential content. Goals (priority order): Completeness → Clarity → Token Optimization. Uses `format-markdown` skill for validation.

**Use when:** Documentation exceeds reasonable length, redundancy detected, content duplicated from referenced files.

**Do NOT use when:** Document already optimized, or content cannot be reduced without losing meaning.

### 1.1 Persona Usage

**Default Persona:** Technical Writer (see `RULE_Persona.md` Section 2.3)

| Document Type | Additional Personas                           |
|---------------|-----------------------------------------------|
| `RULE_*`      | Information Architect (taxonomy, navigation)  |
| `SKILL_*`     | Information Architect + Software Engineer     |
| `IDEA_*`      | Game Designer or relevant domain expert       |
| `SNIPPET_*`   | Software Engineer (code accuracy)             |
| `AUDIT_*`     | Relevant audit persona from `RULE_Persona.md` |
| `SUMMARY_*`   | Information Architect (discoverability)       |

**Workflow:** Technical Writer lens first → document-specific persona → synthesize recommendations.

### 1.2 Optimization Tiers

**🚨 CRITICAL:** Determine tier FIRST before applying techniques.

| Location           | Tier         | Target Reduction | Style                    |
|--------------------|--------------|------------------|--------------------------|
| `Olympus.Agentic/` | Aggressive   | 50-70%           | Terse, tables over prose |
| `.ai-context/`     | Balanced     | 30-50%           | Concise, clear           |
| `AGENTS.md` (root) | Aggressive   | 50-70%           | Terse, tables over prose |
| Other root `*.md`  | Humans       | 20-40%           | Cohesive, flowing        |

## 2. Optimization Techniques

| Technique                 | Before                       | After                              |
|---------------------------|------------------------------|------------------------------------|
| **Table Conversion**      | Verbose list items           | Structured table                   |
| **Cross-Reference**       | Full definitions repeated    | `See RULE_Markdown.md Section 6`   |
| **Section Consolidation** | Scattered related sections   | Single merged section              |
| **Example Reduction**     | 3+ wrong/correct pairs       | Single pair per concept            |

**Essential Content (Must Preserve):** Critical rules (🚨❌ severity), self-verification checklists, cross-references, unique information.

## 3. Execution Workflow

**Step 1: Analyze Document**
1. Read entire document, record metrics (lines, sections, TOC)
2. Identify document type and **determine optimization tier** per Section 1.2
3. **Run `format-markdown` skill** for baseline compliance

**Step 2: Plan Optimization**
1. Present analysis with identified redundancies
2. Specify tier and target reduction range
3. Get user approval before changes

**Step 3: Apply Changes**
1. Apply tier-appropriate optimizations from Section 2
2. Update Last Updated date if content changes
3. Preserve all checklists (add if missing)

**Step 4: Validate Results**
1. **Run `format-markdown` skill** final validation
2. Calculate reduction metrics
3. Verify reduction within tier target range
4. Present results to user

**Output (File):** Edited target file (template: none)
**Output (Console):** Reduction metrics (template: Section 6)

## 4. SNIPPET Implementation Audit

**Trigger:** When reviewing SNIPPET files in `.ai-context/`

**Process:**
1. Identify corresponding IDEA file (e.g., `SNIPPET_OrderProcessing.md` → `IDEA_OrderProcessing.md`)
2. Analyze codebase for implemented features:
   - Check source files for matching components/services
   - Review git commits for implementation evidence
3. For each SNIPPET section:
   - If fully implemented: Mark for removal
   - If partially implemented: Keep unimplemented portions
4. If ALL sections implemented: Recommend deleting entire file (see `RULE_Document.md` Section 3.4)

**Verification:**
- [ ] Codebase files checked against SNIPPET code
- [ ] Git history reviewed for implementation commits
- [ ] Corresponding IDEA sections cross-referenced
- [ ] Removal recommendations documented with evidence

## 5. Self-Assessment Protocol

**🚨 CRITICAL:** Before presenting results, verify:

- [ ] Optimization tier correctly identified per Section 1.2
- [ ] Tier-appropriate techniques applied throughout
- [ ] Reduction percentage within tier target range
- [ ] All critical rules (🚨/❌ severity) preserved
- [ ] Self-verification checklists maintained or added
- [ ] Cross-references accurate and files exist
- [ ] Key workflows and processes intact
- [ ] `format-markdown` skill validation passed
- [ ] Last Updated date current (if content changed)
- [ ] TOC updated to reflect new structure
- [ ] Before and after line counts recorded

## 6. Report Template

| Metric      | Before           | After           | Reduction             |
|-------------|------------------|-----------------|-----------------------|
| Lines       | `{before_lines}` | `{after_lines}` | `{reduction_percent}` |
| Sections    | `{before_lines}` | `{after_lines}` | `{reduction_percent}` |
| TOC Entries | `{before_lines}` | `{after_lines}` | `{reduction_percent}` |

**Key Changes:**
- `{change_description}` (e.g., Consolidated sections, Converted to tables)
