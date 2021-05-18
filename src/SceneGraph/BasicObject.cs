using System;
using System.Collections.Generic;
using System.Numerics;

using VoxelEngine.Spatial;

namespace VoxelEngine.SceneGraph {
  public abstract class BasicObject {
    #region FIELDS
    #region INHERITANCE_VARS
    /// <summary>The Scene the object is in.</summary>
    public readonly Scene scene;
    /// <summary>The object parent.</summary>
    private BasicObject parent;
    /// <summary>Chidren of the current object.</summary>
    private readonly HashSet<BasicObject> children;
    #endregion

    #region PHYSICS
    /// <summary>The mass of the object.</summary>
    public float mass;

    /// <summary>Current linear acceleration of the object.</summary>
    public Vector3 velocity;

    /// <summary>Current angular acceleration of the object.</summary>
    public Quaternion angularVelocity;
    #endregion

    #region POSITIONING
    /// <summary>The local matrix that represents scale, rotation and position.</summary>
    public Matrix4x4 matrixLocal;

    /// <summary>The glocal matrix that represents scale, rotation and position.</summary>
    public Matrix4x4 matrixWorld;
    #endregion
    #endregion

    public bool HasParent => this.parent is not null;
    public BasicObject Parent => this.parent;

    #region Position
    public Vector3 WorldPosition {
      get => this.matrixWorld.Translation;
      set => this.matrixWorld.Translation = value;
    }

    public Vector3 LocalPosition {
      get => this.matrixLocal.Translation;
      set => this.matrixLocal.Translation = value;
    }
    #endregion

    #region ROTATION
    public Quaternion WorldRotation {
      get => this.matrixWorld.GetQuaternion();
      set => this.matrixWorld *= Matrix4x4.CreateFromQuaternion(value);
    }

    public Quaternion LocalRotation {
      get => this.matrixLocal.GetQuaternion();
      set => this.matrixLocal *= Matrix4x4.CreateFromQuaternion(value);
    }
    #endregion

    public BasicObject() {
      this.children = new();
    }

    public void LookAt(Vector3 position, Vector3 up) {
      // TODO: Implement LookAt(Vector3 position, Vector3 up)
      throw new NotImplementedException();
    }

    public void LookAt(Vector3 position) {
      // TODO: Implement LookAt(Vector3 position)
      throw new NotImplementedException();
    }

    /// <summary>Apply the force using the supplied time.</summary>
    /// <returns>The current velocity</returns>
    public Vector3 ApplyForce(Vector3 force, float deltaT) {
      // TODO: Implement ApplyForce(Vector3 force, float deltaT from the Physics
      throw new NotImplementedException();
    }

    /// <summary>Apply the force using the time from the last physics frame.</summary>
    /// <returns>The current velocity</returns>
    public Vector3 ApplyForce(Vector3 force) {
      // TODO: Implement ApplyForce(Vector3 force) from the Physics
      throw new NotImplementedException();
    }

    public HashSet<BasicObject> GetAllChildren() => this.children;

    #region INHERITANCE_METHODS
    public bool HasChildren() => this.children.Count > 0;

    public bool HasChildren(BasicObject obj) => this.children.Contains(obj);

    public void ClearParent() {
      this.parent.RemoveChildren(this, false);
      this.parent = null;
    }

    public void AddChild(BasicObject obj) {
      obj.SetParent(obj);
      this.children.Add(obj);
    }

    /// <summary>Remove the specified object from the children list.</summary>
    /// <param name="obj">The object to be removed</param>
    /// <param name="removeParentFromChildren"></param>
    private bool RemoveChildren(BasicObject obj, bool removeParentFromChildren = true) {
      if (removeParentFromChildren) {
        obj.ClearParent();
      }
      return this.children.Remove(obj);
    }

    /// <summary>Remove the specified object from the children list.</summary>
    /// <param name="obj">The object to be removed</param>
    /// <param name="removeParentFromChildren"></param>
    public bool RemoveChildren(BasicObject obj) {
      return this.RemoveChildren(obj, true);
    }

    public void SetParent(BasicObject obj) {
      if (this.parent is not null) {
        this.parent.RemoveChildren(this);
      }
      this.parent = obj;
      obj.AddChild(this);
    }
    #endregion

    #region ABSTRACT_METHODS
    #region
  }

  public class ObjectHasNoParentException : Exception { }
}
