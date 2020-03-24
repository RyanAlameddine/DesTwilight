using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class FileFunctions
{
    public static T[] GetAtPath<T>(string path) where T : UnityEngine.Object
    {
        T[] res = Resources.LoadAll<T>(path);
        return res;

        //ArrayList al = new ArrayList();
        //string[] fileEntries = Directory.GetFiles(Application.dataPath + "/Resources/" + path);

        //foreach (string fileName in fileEntries)
        //{
        //    string temp = fileName.Replace("\\", "/");
        //    int index = temp.LastIndexOf("/");
        //    string localPath = path;

        //    if (index > 0)
        //        localPath += temp.Substring(index);

        //    localPath = Path.ChangeExtension(localPath, null);

        //    Object t = Resources.Load(localPath, typeof(T));

        //    if (t != null)
        //        al.Add(t);
        //}

        //T[] result = new T[al.Count];

        //for (int i = 0; i < al.Count; i++)
        //    result[i] = (T)al[i];

        //return result;
    }

    public static T[] GetAtPathByName<T>(string path, string name) where T : UnityEngine.Object
    {
        T[] res = Resources.LoadAll<T>(path);
        List<T> cutDown = new List<T>();
        for(int i = 0; i < res.Length; i++)
        {
            if (res[i].name.Contains(name))
            {
                cutDown.Add(res[i]);
            }
            else
            {
                Resources.UnloadAsset(res[i]);
            }
        }

        return cutDown.ToArray();

        //ArrayList al = new ArrayList();
        //string[] fileEntries = Directory.GetFiles(Application.dataPath + "/Resources/" + path);

        //foreach (string fileName in fileEntries)
        //{
        //    if (!fileName.Contains(name)) continue;
        //    string temp = fileName.Replace("\\", "/");
        //    int index = temp.LastIndexOf("/");
        //    string localPath = path;

        //    if (index > 0)
        //        localPath += temp.Substring(index);

        //    localPath = Path.ChangeExtension(localPath, null);

        //    Object t = Resources.Load(localPath, typeof(T));

        //    if (t != null)
        //        al.Add(t);
        //}

        //T[] result = new T[al.Count];

        //for (int i = 0; i < al.Count; i++)
        //    result[i] = (T)al[i];

        //return result;
    }
}
