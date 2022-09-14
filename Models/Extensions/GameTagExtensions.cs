using TGS.Core.Models.Enums;
using static TGS.Core.Models.Enums.GameTag;

namespace TGS.Core.Models.Extensions;

public static class GameTagExtensions
{
    public static GameTag AddTag(this GameTag tags, GameTag newTag)
        => (tags & newTag) != newTag ? tags ^ newTag : tags;

    public static bool IsHot(this GameTag tag) => tag.Is(Hot);

    public static bool IsNew(this GameTag tag) => tag.Is(New);

    public static bool IsRecommend(this GameTag tag) => tag.Is(Recommend);

    public static GameTag RemoveTag(this GameTag tags, GameTag oldTag)
        => (tags & oldTag) == oldTag ? tags ^ oldTag : tags;

    private static bool Is(this GameTag tag, GameTag expected) =>
            (tag & expected) == expected;
}
