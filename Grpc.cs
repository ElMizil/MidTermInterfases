// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: grpc.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace RPCDemoClient {

  /// <summary>Holder for reflection information generated from grpc.proto</summary>
  public static partial class GrpcReflection {

    #region Descriptor
    /// <summary>File descriptor for grpc.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GrpcReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgpncnBjLnByb3RvEgRncnBjGhtnb29nbGUvcHJvdG9idWYvZW1wdHkucHJv",
            "dG8iIwoLQ29vcmRpbmF0ZXMSCQoBeBgBIAEoARIJCgF5GAIgASgBMkUKBEdS",
            "UEMSPQoOR2V0Q29vcmRpbmF0ZXMSFi5nb29nbGUucHJvdG9idWYuRW1wdHka",
            "ES5ncnBjLkNvb3JkaW5hdGVzIgBCOgoVaW8uZ3JwYy5leGFtcGxlcy5ncnBj",
            "QglnUlBDUHJvdG9QAaICA0dSUKoCDVJQQ0RlbW9DbGllbnRiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::RPCDemoClient.Coordinates), global::RPCDemoClient.Coordinates.Parser, new[]{ "X", "Y" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Coordinates : pb::IMessage<Coordinates> {
    private static readonly pb::MessageParser<Coordinates> _parser = new pb::MessageParser<Coordinates>(() => new Coordinates());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Coordinates> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::RPCDemoClient.GrpcReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Coordinates() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Coordinates(Coordinates other) : this() {
      x_ = other.x_;
      y_ = other.y_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Coordinates Clone() {
      return new Coordinates(this);
    }

    /// <summary>Field number for the "x" field.</summary>
    public const int XFieldNumber = 1;
    private double x_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double X {
      get { return x_; }
      set {
        x_ = value;
      }
    }

    /// <summary>Field number for the "y" field.</summary>
    public const int YFieldNumber = 2;
    private double y_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Y {
      get { return y_; }
      set {
        y_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Coordinates);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Coordinates other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (X != other.X) return false;
      if (Y != other.Y) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (X != 0D) hash ^= X.GetHashCode();
      if (Y != 0D) hash ^= Y.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (X != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(X);
      }
      if (Y != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Y);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (X != 0D) {
        size += 1 + 8;
      }
      if (Y != 0D) {
        size += 1 + 8;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Coordinates other) {
      if (other == null) {
        return;
      }
      if (other.X != 0D) {
        X = other.X;
      }
      if (other.Y != 0D) {
        Y = other.Y;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 9: {
            X = input.ReadDouble();
            break;
          }
          case 17: {
            Y = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
