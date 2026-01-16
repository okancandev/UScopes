using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Okancandev.UScopes
{
    public static class UScopesSceneExtensions
    {
        public static UScopesInstance UScopesInstance(this Scene scene)
        {
            return UScopes.DefaultInstance;
        }
        
        public static Scope Scope(this Scene scene, bool createIfNotExist = true)
        {
            return UScopes.Scene(scene, createIfNotExist);
        }

        public static Scope GlobalScope(this Scene scene, bool createIfNotExist = true)
        {
            return UScopes.Global(createIfNotExist);
        }
        
        public static ScopeLookup ScopeLookup(this Scene scene)
        {
            return new ScopeLookup(scene);
        }
        
        public static ScopeLookup ScopeLookup(this MonoBehaviour behaviour)
        {
            return new ScopeLookup(behaviour.gameObject);
        }
    }

    public static class UScopesGameObjectExtensions
    {
        public static UScopesInstance UScopesInstance(this GameObject gameObject)
        {
            return UScopes.DefaultInstance;
        }
        
        public static Scope Scope(this GameObject gameObject, bool createIfNotExist = true)
        {
            return UScopes.GameObject(gameObject, createIfNotExist);
        }
        
        public static Scope SceneScope(this GameObject gameObject, bool createIfNotExist = true)
        {
            return UScopes.Scene(gameObject.scene, createIfNotExist);
        }
        
        public static Scope ActiveSceneScope(this GameObject gameObject, bool createIfNotExist = true)
        {
            return UScopes.ActiveScene(createIfNotExist);
        }

        public static Scope GlobalScope(this GameObject gameObject, bool createIfNotExist = true)
        {
            return UScopes.Global(createIfNotExist);
        }
        
        public static ScopeLookup ScopeLookup(this GameObject gameObject)
        {
            return new ScopeLookup(gameObject);
        }
    }

    public static class UScopesComponentExtensions
    {
        public static UScopesInstance UScopesInstance(this Component component)
        {
            return UScopes.DefaultInstance;
        }
        
        public static Scope Scope(this Component component, bool createIfNotExist = true)
        {
            return UScopes.GameObject(component.gameObject, createIfNotExist);
        }
        
        public static Scope SceneScope(this Component component, bool createIfNotExist = true)
        {
            return UScopes.Scene(component.gameObject.scene, createIfNotExist);
        }
        
        public static Scope ActiveSceneScope(this Component component, bool createIfNotExist = true)
        {
            return UScopes.ActiveScene(createIfNotExist);
        }

        public static Scope GlobalScope(this Component component, bool createIfNotExist = true)
        {
            return UScopes.Global(createIfNotExist);
        }
        
        public static ScopeLookup ScopeLookup(this Component component)
        {
            return new ScopeLookup(component);
        }
    }

    public static class UScopesMonoBehaviourExtensions
    {
        public static object Get(this MonoBehaviour behaviour, ServiceIdentifier identifier) 
        {
            return behaviour.ScopeLookup().Get(identifier);
        }
        
        public static bool TryGet(this MonoBehaviour behaviour, ServiceIdentifier identifier, out object service) 
        {
            return behaviour.ScopeLookup().TryGet(identifier, out service);
        }
        
        public static bool TryGet<T>(this MonoBehaviour behaviour, ServiceIdentifier identifier, out T service) 
        {
            return behaviour.ScopeLookup().TryGet(identifier, out service);
        }
        
        public static object GetOrDefault(this MonoBehaviour behaviour, ServiceIdentifier identifier, object defaultValue = null) 
        {
            return TryGet(behaviour, identifier, out object value) 
                ? value 
                : defaultValue;
        }
        
        public static object GetSingle(this MonoBehaviour behaviour, Type type)
        {
            return Get(behaviour, new ServiceIdentifier(type));
        }
        
        public static object GetTagged(this MonoBehaviour behaviour, Type type, object tag)
        {
            return Get(behaviour, new ServiceIdentifier(type, tag));
        }
        
        public static object GetWithId(this MonoBehaviour behaviour, Type type, long id)
        {
            return Get(behaviour, new ServiceIdentifier(type, id));
        }
        
        public static object GetTaggedWithId(this MonoBehaviour behaviour, Type type, object tag, long id)
        {
            return Get(behaviour, new ServiceIdentifier(type, tag, id));
        }
        
        public static T GetSingle<T>(this MonoBehaviour behaviour)
        {
            return (T)Get(behaviour, new ServiceIdentifier(typeof(T)));
        }
        
        public static T GetTagged<T>(this MonoBehaviour behaviour, object tag)
        {
            return (T)Get(behaviour, new ServiceIdentifier(typeof(T), tag));
        }
        
        public static T GetWithId<T>(this MonoBehaviour behaviour, long id)
        {
            return (T)Get(behaviour, new ServiceIdentifier(typeof(T), id));
        }
        
        public static T GetTaggedWithId<T>(this MonoBehaviour behaviour, object tag, long id)
        {
            return (T)Get(behaviour, new ServiceIdentifier(typeof(T), tag, id));
        }
        
        public static bool TryGetSingle(this MonoBehaviour behaviour, Type serviceType, out object service) 
        {
            return TryGet(behaviour, new ServiceIdentifier(serviceType), out service);
        }
        
        public static bool TryGetTagged(this MonoBehaviour behaviour, Type serviceType, object tag, out object service)
        {
            return TryGet(behaviour, new ServiceIdentifier(serviceType, tag), out service);
        }
        
        public static bool TryGetWithId(this MonoBehaviour behaviour, Type serviceType, long id, out object service) 
        {
            return TryGet(behaviour, new ServiceIdentifier(serviceType, id), out service);
        }
        
        public static bool TryGetTaggedWithId(this MonoBehaviour behaviour, Type serviceType, object tag, long id, out object service) 
        {
            return TryGet(behaviour, new ServiceIdentifier(serviceType, tag, id), out service);
        }

        public static bool TryGetSingle<T>(this MonoBehaviour behaviour, out T service)
        {
            return TryGet(behaviour, new ServiceIdentifier(typeof(T)), out service);
        }
        
        public static bool TryGetTagged<T>(this MonoBehaviour behaviour, object tag, out T service)
        {
            return TryGet(behaviour, new ServiceIdentifier(typeof(T), tag), out service);
        }
        
        public static bool TryGetWithId<T>(this MonoBehaviour behaviour, long id, out T service) 
        {
            return TryGet(behaviour, new ServiceIdentifier(typeof(T), id), out service);
        }
        
        public static bool TryGetTaggedWithId<T>(this MonoBehaviour behaviour, object tag, long id, out T service) 
        {
            return TryGet(behaviour, new ServiceIdentifier(typeof(T), tag, id), out service);
        }
        
        public static object GetSingleOrDefault(this MonoBehaviour behaviour, Type type, object defaultValue = null)
        {
            return TryGetSingle(behaviour, type, out object value) 
                ? value 
                : defaultValue;
        }
        
        public static object GetTaggedOrDefault(this MonoBehaviour behaviour, Type type, object tag, object defaultValue = null)
        {
            return TryGetTagged(behaviour, type, tag, out object value) 
                ? value 
                : defaultValue;
        }
        
        public static object GetWithIdOrDefault(this MonoBehaviour behaviour, Type type, long id, object defaultValue = null)
        {
            return TryGetWithId(behaviour, type, id, out object value) 
                ? value 
                : defaultValue;
        }
        
        public static object GetTaggedWithIdOrDefault(this MonoBehaviour behaviour, Type type, object tag, long id , object defaultValue = null)
        {
            return TryGetTaggedWithId(behaviour, type, tag, id, out object value) 
                ? value 
                : defaultValue;
        }
        
        public static T GetSingleOrDefault<T>(this MonoBehaviour behaviour, T defaultValue = default)
        {
            return TryGetSingle(behaviour, out T value) 
                ? value 
                : defaultValue;
        }
        
        public static T GetTaggedOrDefault<T>(this MonoBehaviour behaviour, object tag, T defaultValue = default)
        {
            return TryGetTagged(behaviour, tag, out T value) 
                ? value 
                : defaultValue;
        }
        
        public static T GetWithIdOrDefault<T>(this MonoBehaviour behaviour, long id, T defaultValue = default)
        {
            return TryGetWithId(behaviour, id, out T value) 
                ? value 
                : defaultValue;
        }
        
        public static T GetTaggedWithIdOrDefault<T>(this MonoBehaviour behaviour, object tag, long id, T defaultValue = default)
        {
            return TryGetTaggedWithId(behaviour, tag, id, out T value) 
                ? value 
                : defaultValue;
        }
    }
}