using UnityEngine;

namespace TimberApi.AssetSystem
{
    public interface IAssetLoader
    {
        /// <summary>
        ///     Resource path delimiter that can be used to rewrite the stock game paths.
        /// </summary>
        /// <seealso cref="Load{T}(string)"/>
        const string ResetPathDelimiter = "_TAPI_RESOURCE_/";

        /// <summary>
        ///     Load a single asset with path string
        ///     Example: Prefix/Subfolder/Filename/ButtonUI
        /// </summary>
        /// <param name="path">
        /// Path to the asset. If at any place the path contains a sub-string <see cref="ResetPathDelimiter"/>, then
        /// any content before this prefix is disregarded. This can be used to override the stock game paths when the
        /// resource path is dynamically constructed inside the game code. 
        /// </param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T Load<T>(string path) where T : Object;

        /// <summary>
        ///     Load a single asset with prefix and path string
        /// </summary>
        /// <param name="prefix">Prefix that used in the register</param>
        /// <param name="path">Path to asset without the prefix</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T Load<T>(string prefix, string path) where T : Object;

        /// <summary>
        ///     Load a single asset
        /// </summary>
        /// <param name="prefix">Prefix that used in the register</param>
        /// <param name="pathToFile"></param>
        /// <param name="name">name of object</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T Load<T>(string prefix, string pathToFile, string name) where T : Object;

        /// <summary>
        ///     Load all assets inside bundle
        ///     Example: Prefix/Subfolder/Filename
        /// </summary>
        /// <param name="path">Path to the asset</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T[] LoadAll<T>(string path) where T : Object;

        /// <summary>
        ///     Load all assets inside bundle
        /// </summary>
        /// <param name="prefix">Prefix that used in the register</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T[] LoadAll<T>(string prefix, string pathToFile) where T : Object;
    }
}