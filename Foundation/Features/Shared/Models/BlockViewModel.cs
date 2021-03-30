using EPiServer.Core;
using Foundation.Features.Shared.Interfaces;

namespace Foundation.Features.Shared.Models
{
    public class BlockViewModel<T> : IBlockViewModel<T> where T : BlockData
    {
        public BlockViewModel(T currentBlock) => CurrentBlock = currentBlock;

        public T CurrentBlock { get; }
    }
}