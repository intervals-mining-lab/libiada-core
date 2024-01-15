namespace LibiadaCore.DataTransformers
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Static class containing all codon to amino-acid coding tables.
    /// </summary>
    public static class DnaCodingTables
    {
        /// <summary>
        ///  Coding tables as dictionary of dictionaries 
        ///  with table numbers and codons as keys.
        /// </summary>
        public static ReadOnlyDictionary<byte, ReadOnlyDictionary<string, IBaseObject>> codingTables = new ReadOnlyDictionary<byte, ReadOnlyDictionary<string, IBaseObject>>(
            new Dictionary<byte, ReadOnlyDictionary<string, IBaseObject>>
        {
                {
                    1, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    2, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"M" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"*" },  { "AGG", (ValueString)"*" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    3, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"T" },  { "CTC", (ValueString)"T" },  { "CTA", (ValueString)"T" },  { "CTG", (ValueString)"T" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" } /* TODO: probably absent */,  { "CGA", (ValueString)"R" } /* TODO: probably absent */,  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"M" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    4, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    5, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"M" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"S" },  { "AGG", (ValueString)"S" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    6, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"Q" },  { "TAG", (ValueString)"Q" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    9, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"N" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"S" },  { "AGG", (ValueString)"S" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    10, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"C" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    11, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    12, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"S" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    13, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"M" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"G" },  { "AGG", (ValueString)"G" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    14, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"Y" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"N" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"S" },  { "AGG", (ValueString)"S" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    15, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"Q" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    16, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"L" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    21, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"M" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"N" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"S" },  { "AGG", (ValueString)"S" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    22, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"*" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"L" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    23, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"*" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    24, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"S" },  { "AGG", (ValueString)"K" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    25, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"G" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    26, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"*" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"A" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    27, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"Q" },  { "TAG", (ValueString)"Q" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", new ValuePhantom() { (ValueString)"*", (ValueString)"W" } },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    28, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", new ValuePhantom() { (ValueString)"*", (ValueString)"Q" } },  { "TAG", new ValuePhantom() { (ValueString)"*", (ValueString)"Q" } },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", new ValuePhantom() { (ValueString)"*", (ValueString)"W" } },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    29, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"Y" },  { "TAG", (ValueString)"Y" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    30, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"E" },  { "TAG", (ValueString)"E" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"*" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    31, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", new ValuePhantom() { (ValueString)"*", (ValueString)"E" } },  { "TAG", new ValuePhantom() { (ValueString)"*", (ValueString)"E" } },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"R" },  { "AGG", (ValueString)"R" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })},
            {
                    33, new ReadOnlyDictionary<string, IBaseObject>(new Dictionary<string, IBaseObject>
            {
                { "TTT", (ValueString)"F" },  { "TTC", (ValueString)"F" },  { "TTA", (ValueString)"L" },  { "TTG", (ValueString)"L" },
                { "TCT", (ValueString)"S" },  { "TCC", (ValueString)"S" },  { "TCA", (ValueString)"S" },  { "TCG", (ValueString)"S" },
                { "TAT", (ValueString)"Y" },  { "TAC", (ValueString)"Y" },  { "TAA", (ValueString)"Y" },  { "TAG", (ValueString)"*" },
                { "TGT", (ValueString)"C" },  { "TGC", (ValueString)"C" },  { "TGA", (ValueString)"W" },  { "TGG", (ValueString)"W" },
                { "CTT", (ValueString)"L" },  { "CTC", (ValueString)"L" },  { "CTA", (ValueString)"L" },  { "CTG", (ValueString)"L" },
                { "CCT", (ValueString)"P" },  { "CCC", (ValueString)"P" },  { "CCA", (ValueString)"P" },  { "CCG", (ValueString)"P" },
                { "CAT", (ValueString)"H" },  { "CAC", (ValueString)"H" },  { "CAA", (ValueString)"Q" },  { "CAG", (ValueString)"Q" },
                { "CGT", (ValueString)"R" },  { "CGC", (ValueString)"R" },  { "CGA", (ValueString)"R" },  { "CGG", (ValueString)"R" },
                { "ATT", (ValueString)"I" },  { "ATC", (ValueString)"I" },  { "ATA", (ValueString)"I" },  { "ATG", (ValueString)"M" },
                { "ACT", (ValueString)"T" },  { "ACC", (ValueString)"T" },  { "ACA", (ValueString)"T" },  { "ACG", (ValueString)"T" },
                { "AAT", (ValueString)"N" },  { "AAC", (ValueString)"N" },  { "AAA", (ValueString)"K" },  { "AAG", (ValueString)"K" },
                { "AGT", (ValueString)"S" },  { "AGC", (ValueString)"S" },  { "AGA", (ValueString)"S" },  { "AGG", (ValueString)"K" },
                { "GTT", (ValueString)"V" },  { "GTC", (ValueString)"V" },  { "GTA", (ValueString)"V" },  { "GTG", (ValueString)"V" },
                { "GCT", (ValueString)"A" },  { "GCC", (ValueString)"A" },  { "GCA", (ValueString)"A" },  { "GCG", (ValueString)"A" },
                { "GAT", (ValueString)"D" },  { "GAC", (ValueString)"D" },  { "GAA", (ValueString)"E" },  { "GAG", (ValueString)"E" },
                { "GGT", (ValueString)"G" },  { "GGC", (ValueString)"G" },  { "GGA", (ValueString)"G" },  { "GGG", (ValueString)"G" }
            })}
        });
    }
}
