/* Copyright (c) 2018, Ádám L. Juhász
 *
 * This file is part of AquariaRecepies.
 *
 * AquariaRecepies is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AquariaRecepies is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AquariaRecepies.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static System.Math;
using static System.String;

namespace JAL.Utilities
{
    public class SemanticVersion : ICloneable, IEquatable<SemanticVersion>, IComparable, IComparable<SemanticVersion>, IFormattable
    {
        private enum ParsingPhase
        {
            Major,
            Minor,
            Patch,
            PreRelease,
            MetaData,
        }

        public static readonly SemanticVersion Empty = new SemanticVersion();

        public uint Major { get; }

        public uint Minor { get; }

        public uint Patch { get; }

        public IReadOnlyList<string> PreRelease { get; }

        public IReadOnlyList<string> MetaData { get; }

        public static bool ValidIdentifier(string identifier)
        {
            return identifier.Length > 0
            // only digits and no leading zero.
                && (identifier.All(c => c >= '0' && c <= '9') && (identifier.Length == 1 || identifier.First() != '0')
            // Have other than digits but only alphanumeric, and hyphen.
                 || identifier.Any(c => c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c == '-')
                  && identifier.All(c => c >= '0' && c <= '9' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c == '-'));
        }
        
        public static SemanticVersion Parse(string version)
        {
            try
            {
                return new SemanticVersion(version);
            }
            catch (ArgumentException ex)
            {
                throw new FormatException("The format of the provided string is not a valid version string.", ex);
            }
        }

        public static bool TryParse(string input, out SemanticVersion version)
        {
            try
            {
                version = Parse(input);
                return true;
            }
            catch (FormatException)
            {
                version = Empty;
                return false;
            }
        }

        private static string ObjectAsString(object obj)
        {
            return (obj as IFormattable)?.ToString(null, CultureInfo.InvariantCulture) ?? obj.ToString();
        }

        public SemanticVersion(string version) : this()
        {
            string acc = "";
            ParsingPhase phase = 0;
            List<string> identifiers = new List<string>();
            uint? vernodeResult;

            foreach (char c in version)
            {
                switch (phase)
                {
                    case ParsingPhase.Major:
                        vernodeResult = ProcessVersionNode(c);
                        if (vernodeResult.HasValue) Major = vernodeResult.Value;
                        break;
                    case ParsingPhase.Minor:
                        vernodeResult = ProcessVersionNode(c);
                        if (vernodeResult.HasValue) Minor = vernodeResult.Value;
                        break;
                    case ParsingPhase.Patch:
                        vernodeResult = ProcessVersionNode(c);
                        if (vernodeResult.HasValue) Patch = vernodeResult.Value;
                        break;
                    case ParsingPhase.PreRelease:
                        if (ProcessIdentifiers(c))
                        {
                            PreRelease = identifiers.ToArray();
                            identifiers.Clear();
                        }
                        break;
                    case ParsingPhase.MetaData:
                        if (ProcessIdentifiers(c))
                        {
                            PreRelease = identifiers.ToArray();
                            identifiers.Clear();
                        }
                        break;
                }
            }

            switch (phase)
            {
                case ParsingPhase.Major:
                case ParsingPhase.Minor:
                    throw Error();
                case ParsingPhase.Patch:
                    Patch = ProcessVersionNode(null).Value;
                    break;
                case ParsingPhase.PreRelease:
                    ProcessIdentifiers(null);
                    PreRelease = identifiers.ToArray();
                    break;
                case ParsingPhase.MetaData:
                    ProcessIdentifiers(null);
                    MetaData = identifiers.ToArray();
                    break;
            }

            uint? ProcessVersionNode(char? c)
            {
                uint? result = null;
                switch (c)
                {
                    case char digit when digit >= '0' && digit <= '9':
                        acc += digit;
                        break;
                    case null:
                        GatherResult();
                        break;
                    case char terminate when terminate == '.':
                        GatherResult();
                        switch (phase)
                        {
                            case ParsingPhase.Major:
                                phase = ParsingPhase.Minor;
                                break;
                            case ParsingPhase.Minor:
                                phase = ParsingPhase.Patch;
                                break;
                            case ParsingPhase.Patch:
                                throw Error();
                        }
                        break;
                    case char terminate when terminate == '-':
                        if (phase != ParsingPhase.Patch) throw Error();
                        GatherResult();
                        phase = ParsingPhase.PreRelease;
                        break;
                    case char terminate when terminate == '+':
                        if (phase != ParsingPhase.Patch) throw Error();
                        GatherResult();
                        phase = ParsingPhase.MetaData;
                        break;
                    default:
                        throw Error();
                }
                return result;

                void GatherResult()
                {
                    if (acc.Length > 1 && acc.First() == '0') throw Error();
                    result = uint.Parse(acc, NumberStyles.None);
                    acc = "";
                }
            }

            bool ProcessIdentifiers(char? c)
            {
                switch (c)
                {
                    case null:
                        GatherIdentifier();
                        return true;
                    case char alnum when alnum >= '0' && alnum <= '9' || 
                                         alnum >= 'a' && alnum <= 'z' ||
                                         alnum >= 'A' && alnum <= 'Z':
                        acc += alnum;
                        break;
                    case char terminate when terminate == '.':
                        GatherIdentifier();
                        break;
                    case char terminate when terminate == '+':
                        if (phase == ParsingPhase.MetaData) throw Error();
                        GatherIdentifier();
                        phase = ParsingPhase.MetaData;
                        return true;
                    default:
                        throw Error();
                }

                return false;

                void GatherIdentifier()
                {
                    if (!ValidIdentifier(acc)) throw Error();
                    identifiers.Add(acc);
                    acc = "";
                }
            }

            Exception Error()
            {
                return new ArgumentException($"Malformed version string while parsing node: {phase}", nameof(version));
            }
        }

        public SemanticVersion() : this(0, 0, 0, new object[0], new object[0]) { }

        public SemanticVersion(uint major, uint minor, uint patch)
            : this(major, minor, patch, new object[0], new object[0])
        { }

        public SemanticVersion(uint major, uint minor, uint patch, params object[] preRelease)
            : this(major, minor, patch, preRelease, new object[0])
        { }

        public SemanticVersion(uint major, uint minor, uint patch, IEnumerable<object> preRelease)
            : this(major, minor, patch, preRelease, new object[0])
        { }

        public SemanticVersion(uint major, uint minor, uint patch, IEnumerable<object> preRelease, IEnumerable<object> metadata)
            : this(major, minor, patch, preRelease.Select(ObjectAsString), metadata.Select(ObjectAsString))
        { }

        private SemanticVersion(uint major, uint minor, uint patch, IEnumerable<string> preRelease, IEnumerable<string> metadata)
        {
            if (preRelease == null)
            {
                throw new ArgumentNullException(nameof(preRelease));
            }

            if (!preRelease.All(ValidIdentifier))
            {
                throw new ArgumentException("Pre-release identifiers can only contain ASCII alphanumeric characters, and hyphens.", nameof(preRelease));
            }

            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            if (!metadata.All(ValidIdentifier))
            {
                throw new ArgumentException("Meta-data identifiers can only contain ASCII alphanumeric characters, and hyphens.", nameof(metadata));
            }

            preRelease = preRelease.Select(identifier => identifier ?? "");
            metadata = metadata.Select(identifier => identifier ?? "");

            Major      = major;
            Minor      = minor;
            Patch      = patch;
            PreRelease = preRelease.ToArray();
            MetaData   = metadata.ToArray();
        }

        public override string ToString()
        {
            return ToString("3", null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format != null && format != "0" && format != "1" && format != "2" && format != "3")
                throw new FormatException();

            return $"{Major:#0}.{Minor:#0}.{Patch:#0}" +
                ((format == "1" || format == "3") && PreRelease.Count != 0 ? $"-{Join(".", PreRelease)}" : "") +
                ((format == "2" || format == "3") && MetaData.Count != 0 ? $"+{Join(".", MetaData)}" : "");
        }

        public override int GetHashCode()
        {
            return (int)(Major ^
                (Minor >> 2) ^
                (Patch >> 4) ^
                (PreRelease.Reverse().Aggregate(0u, (a, s) => (a >> 1) ^ (uint)s.GetHashCode()) >> 8));
        }

        public object Clone()
        {
            return new SemanticVersion(Major, Minor, Patch, MetaData, PreRelease.ToArray());
        }

        public bool Equals(SemanticVersion other)
        {
            return !(other is null)
                && Major == other.Major
                && Minor == other.Minor
                && Patch == other.Patch
                && PreRelease.SequenceEqual(other.PreRelease, StringComparer.InvariantCulture);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SemanticVersion);
        }

        public int CompareTo(SemanticVersion other)
        {
            int cmpRes;

            if ((cmpRes = Major.CompareTo(other.Major)) != 0) return cmpRes;
            if ((cmpRes = Minor.CompareTo(other.Minor)) != 0) return cmpRes;
            if ((cmpRes = Patch.CompareTo(other.Patch)) != 0) return cmpRes;

            if (PreRelease.Count == 0 && other.PreRelease.Count == 0) return 0;

            if (other.PreRelease.Count == 0) return -1;

            if (PreRelease.Count == 0) return 1;

            int i;

            for (i = 0; i < Min(PreRelease.Count, other.PreRelease.Count); ++i)
            {
                bool aisint, bisint;

                aisint = int.TryParse(PreRelease[i], NumberStyles.None, CultureInfo.InvariantCulture, out int valueA);
                bisint = int.TryParse(other.PreRelease[i], NumberStyles.None, CultureInfo.InvariantCulture, out int valueB);

                if (aisint && !bisint) return -1;
                if (!aisint && bisint) return 1;

                if (aisint && bisint)
                {
                    if ((cmpRes = valueA.CompareTo(valueB)) != 0) return cmpRes;
                }

                if (!aisint && !bisint)
                {
                    if ((cmpRes = StringComparer.InvariantCulture.Compare(PreRelease[i], other.PreRelease[i])) != 0)
                        return cmpRes;
                }
            }

            if (i < other.PreRelease.Count) return -1;
            if (i < PreRelease.Count) return 1;

            return 0;
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as SemanticVersion ?? throw new ArgumentException("The parameter is not the expected type.", nameof(obj)));
        }

        public static bool operator ==(SemanticVersion a, SemanticVersion b)
        {
            return a?.Equals(b) ?? b is null;
        }

        public static bool operator !=(SemanticVersion a, SemanticVersion b)
        {
            return !a?.Equals(b) ?? !(b is null);
        }

        public static bool operator <(SemanticVersion a, SemanticVersion b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(SemanticVersion a, SemanticVersion b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <=(SemanticVersion a, SemanticVersion b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >=(SemanticVersion a, SemanticVersion b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static explicit operator Version(SemanticVersion version)
        {
            return new Version((int)version.Major, (int)version.Minor);
        }

        public static explicit operator SemanticVersion(Version version)
        {
            return new SemanticVersion((uint)version.Major, (uint)version.Minor, 0);
        }
    }
}
