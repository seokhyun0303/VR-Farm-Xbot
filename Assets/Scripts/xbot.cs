
using Oculus.Interaction.Input;
using Oculus.Interaction.PoseDetection;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class xbot : MonoBehaviour
{
    
    public Animator avatarAnimator;
    public OVRHand lhand, rhand;
    public OVRSkeleton ls, rs;
    GameObject centerEye;
    int c;

    void Start()
    {
        
        if (avatarAnimator == null)
            avatarAnimator = GetComponent<Animator>();
        centerEye = GameObject.Find("CenterEyeAnchor");
        //avatarAnimator.transform.Rotate(new Vector3(0, 180, 0));
        c = 0;   
    }

    void LateUpdate()
    {

        if (c == 0 && rhand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            checkscale();
        }

        operation_head();
        operation_righthand();
        operation_lefthand();
        move_avatar();
        
    }

    void operation_head()
    {
        Transform headBone = avatarAnimator.GetBoneTransform(HumanBodyBones.Head);
        headBone.localRotation = centerEye.transform.localRotation;
    }

    void operation_righthand()
    {
        Transform righthand = avatarAnimator.GetBoneTransform(HumanBodyBones.RightHand);
        //righthand.transform.position = rhand.transform.position;
        //Matrix4x4 rm = Matrix4x4.zero;
        //rm.m02 = -1;
        //rm.m10 = 1;
        //rm.m21 = 1;
        //Quaternion rq = QuaternionFromMatrix(rm);
        //righthand.transform.localRotation = Quaternion.Euler(new Vector3(-90, 90, -75)) * rhand.transform.rotation * rq;  //  no ik 180 90 -90
        righthand.transform.rotation = rhand.transform.rotation;
        //righthand.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        righthand.Rotate(new Vector3(90, 0, 90));
        operation_rthumb();
        operation_rindex();
        operation_rmid();
        operation_rring();
        operation_rpinky();
    }

    void operation_lefthand()
    {
        Transform lefthand = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
        //lefthand.transform.position = lhand.transform.position;
        //Matrix4x4 lm = Matrix4x4.zero;
        //lm.m01 = 1;
        //lm.m12 = 1;
        //lm.m20 = 1;
        //Quaternion lq = QuaternionFromMatrix(lm);
        //lefthand.transform.localRotation = Quaternion.Euler(new Vector3(180, -90, 90)) * lhand.transform.rotation * lq;  // no ik 180 -90 90
        lefthand.transform.rotation = lhand.transform.rotation;
        //lefthand.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        lefthand.Rotate(new Vector3(-90, 0, -90));
        operation_lthumb();
        operation_lindex();
        operation_lmid();
        operation_lring();
        operation_lpinky();
    }

    void operation_lthumb()
    {
        Transform lthumb_d = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftThumbDistal);
        Transform lthumb_i = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate);
        Transform lthumb_p = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftThumbProximal);
        Matrix4x4 lm = Matrix4x4.zero;
        lm.m00 = 1;
        lm.m11 = -1;
        lm.m22 = -1;
        Quaternion lq = QuaternionFromMatrix(lm);
        lthumb_d.localRotation = Quaternion.Euler(new Vector3(0, 180, 180)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.localRotation * lq;
        //lthumb_d.Rotate(new Vector3(180, 0, 90));
        //lthumb_d.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        lthumb_i.localRotation = Quaternion.Euler(new Vector3(-5, 180, 180)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.localRotation * lq;
        //lthumb_i.Rotate(new Vector3(180, 0, 90));
        //lthumb_i.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        lthumb_p.rotation = ls.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.rotation;
        lthumb_p.Rotate(new Vector3(180, 0, 90));
        //lthumb_p.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
    }

    void operation_lindex()
    {
        Transform lindex_d = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftIndexDistal);
        Transform lindex_i = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate);
        Transform lindex_p = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
        Matrix4x4 lm = Matrix4x4.zero;
        lm.m01 = -1;
        lm.m12 = 1; 
        Quaternion lq = QuaternionFromMatrix(lm);
        lindex_d.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.localRotation *lq;
        lindex_i.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.localRotation *lq;
        lindex_p.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.localRotation *lq;
    }

    void operation_lmid()
    {
        Transform lmid_d = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal);
        Transform lmid_i = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate);
        Transform lmid_p = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal);
        Matrix4x4 lm = Matrix4x4.zero;
        lm.m01 = -1;
        lm.m12 = 1;
        Quaternion lq = QuaternionFromMatrix(lm);
        lmid_d.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.localRotation *lq;
        lmid_i.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.localRotation *lq;
        lmid_p.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.localRotation *lq ;
    }

    void operation_lring()
    {
        Transform lring_d = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftRingDistal);
        Transform lring_i = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate);
        Transform lring_p = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftRingProximal);
        Matrix4x4 lm = Matrix4x4.zero;
        lm.m01 = -1;
        lm.m12 = 1;
        Quaternion lq = QuaternionFromMatrix(lm);
        lring_d.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.localRotation * lq;
        lring_i.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.localRotation * lq;
        lring_p.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.localRotation * lq;
    }

    void operation_lpinky()
    {
        Transform lpinky_d = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftLittleDistal);
        Transform lpinky_i = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate);
        Transform lpinky_p = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftLittleProximal);
        Matrix4x4 lm = Matrix4x4.zero;
        lm.m01 = -1;
        lm.m12 = 1;
        Quaternion lq = QuaternionFromMatrix(lm);
        lpinky_d.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.localRotation * lq;
        //lpinky_d.Rotate(new Vector3(-90, 0, 90));
        //lpinky_d.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        lpinky_i.localRotation = Quaternion.Euler(new Vector3(180, 90, 90)) * ls.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.localRotation * lq;
        //lpinky_i.Rotate(new Vector3(-90, 0, 90));
        //lpinky_i.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        lpinky_p.rotation = ls.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.rotation;
        lpinky_p.Rotate(new Vector3(-90, 0, 90));
        //lpinky_p.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
    }

    void operation_rthumb()
    {
        Transform rthumb_d = avatarAnimator.GetBoneTransform(HumanBodyBones.RightThumbDistal);
        Transform rthumb_i = avatarAnimator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
        Transform rthumb_p = avatarAnimator.GetBoneTransform(HumanBodyBones.RightThumbProximal);
        Matrix4x4 rm = Matrix4x4.zero;
        rm.m00 = 1;
        rm.m11 = 1;
        rm.m22 = 1;
        Quaternion rq = QuaternionFromMatrix(rm);
        rthumb_d.localRotation = Quaternion.Euler(new Vector3(0, 0, 0)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.localRotation * rq;
        //rthumb_d.Rotate(new Vector3(0, 0, -90));  // no ik 0 0 -90
        //rthumb_d.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        rthumb_i.localRotation = Quaternion.Euler(new Vector3(5, 0, 0)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.localRotation * rq;
        //rthumb_i.Rotate(new Vector3(0, 0, -90));
        //rthumb_i.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        rthumb_p.rotation = rs.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.rotation;
        rthumb_p.Rotate(new Vector3(0, 0, -90));
        //rthumb_p.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
    }

    void operation_rindex()
    {
        Transform rindex_d = avatarAnimator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
        Transform rindex_i = avatarAnimator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
        Transform rindex_p = avatarAnimator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
        Matrix4x4 rm = Matrix4x4.zero;
        rm.m01 = 1;
        rm.m12 = -1;
        Quaternion rq = QuaternionFromMatrix(rm);
        rindex_d.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.localRotation * rq;  
        //rindex_d.Rotate(new Vector3(90, 0, -90));
        rindex_i.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.localRotation * rq;
        //rindex_i.Rotate(new Vector3(90, 0, -90));
        rindex_p.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.localRotation * rq;
        //rindex_p.Rotate(new Vector3(90, 0, -90));
    }

    void operation_rmid()
    {
        Transform rmid_d = avatarAnimator.GetBoneTransform(HumanBodyBones.RightMiddleDistal);
        Transform rmid_i = avatarAnimator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate);
        Transform rmid_p = avatarAnimator.GetBoneTransform(HumanBodyBones.RightMiddleProximal);
        Matrix4x4 rm = Matrix4x4.zero;
        rm.m01 = 1;
        rm.m12 = -1;
        Quaternion rq = QuaternionFromMatrix(rm);
        rmid_d.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.localRotation * rq;
        rmid_i.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.localRotation * rq;
        rmid_p.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.localRotation * rq;
    }

    void operation_rring()
    {
        Transform rring_d = avatarAnimator.GetBoneTransform(HumanBodyBones.RightRingDistal);
        Transform rring_i = avatarAnimator.GetBoneTransform(HumanBodyBones.RightRingIntermediate);
        Transform rring_p = avatarAnimator.GetBoneTransform(HumanBodyBones.RightRingProximal);
        Matrix4x4 rm = Matrix4x4.zero;
        rm.m01 = 1;
        rm.m12 = -1;
        Quaternion rq = QuaternionFromMatrix(rm);
        rring_d.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.localRotation * rq;
        rring_i.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.localRotation * rq;
        rring_p.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.localRotation * rq;
    }

    void operation_rpinky()
    {
        Transform rpinky_d = avatarAnimator.GetBoneTransform(HumanBodyBones.RightLittleDistal);
        Transform rpinky_i = avatarAnimator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate);
        Transform rpinky_p = avatarAnimator.GetBoneTransform(HumanBodyBones.RightLittleProximal);
        Matrix4x4 rm = Matrix4x4.zero;
        rm.m01 = 1;
        rm.m12 = -1;
        Quaternion rq = QuaternionFromMatrix(rm);
        rpinky_d.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.localRotation * rq;
        //rpinky_d.Rotate(new Vector3(90, 0, -90)); 
        //rpinky_d.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        rpinky_i.localRotation = Quaternion.Euler(new Vector3(180, 90, -90)) * rs.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.localRotation * rq;
        //rpinky_i.Rotate(new Vector3(90, 0, -90));
        //rpinky_i.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
        rpinky_p.rotation = rs.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.rotation;
        rpinky_p.Rotate(new Vector3(90, 0, -90));
        //rpinky_p.Rotate(avatarAnimator.transform.eulerAngles, Space.World);
    }

    void move_avatar()
    {
        Vector3 head = centerEye.transform.position;
        Vector3 r = centerEye.transform.rotation.eulerAngles;
        r[0] = 0;
        r[2] = 0;
        avatarAnimator.transform.position = head + new Vector3(0, -0.5f, 0); 
        avatarAnimator.transform.rotation = Quaternion.Euler(r);
    }

    void checkscale()
    {
        Transform lefthand = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
        Transform headBone = avatarAnimator.GetBoneTransform(HumanBodyBones.Head);
        Transform uarm = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        Transform larm = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftLowerArm);

        Vector3 head = centerEye.transform.position;
        Vector3 hand = lhand.transform.position;
        Vector3 modelhand = lefthand.transform.position;
        Vector3 ua = uarm.transform.position;   
        Vector3 la = larm.transform.position;
        float modelarm = Mathf.Sqrt(Mathf.Pow((ua[0] - la[0]), 2) + Mathf.Pow((ua[1] - la[1]), 2) + Mathf.Pow((ua[2] - la[2]), 2)) + Mathf.Sqrt(Mathf.Pow((modelhand[0] - la[0]), 2) + Mathf.Pow((modelhand[1] - la[1]), 2) + Mathf.Pow((modelhand[2] - la[2]), 2));
        float user = Mathf.Sqrt(Mathf.Pow((head[0] - hand[0]), 2) + Mathf.Pow((head[2] - hand[2]), 2)) + 0.09f;
        float userarm = Mathf.Sqrt(Mathf.Pow(user,2) - Mathf.Pow(0.2f,2));
        if (userarm > modelarm)
        {
            avatarAnimator.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
        }
        else
        {
            avatarAnimator.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
        }
        if (Math.Abs(userarm - modelarm) < 0.0005f)
        {
            c = 1;
        }

    }

    Quaternion QuaternionFromMatrix(Matrix4x4 m)
    {
        Quaternion q = new Quaternion();
        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] + m[1, 1] + m[2, 2])) / 2;
        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] - m[1, 1] - m[2, 2])) / 2;
        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] + m[1, 1] - m[2, 2])) / 2;
        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] - m[1, 1] + m[2, 2])) / 2;
        q.x *= Mathf.Sign(q.x * (m[2, 1] - m[1, 2]));
        q.y *= Mathf.Sign(q.y * (m[0, 2] - m[2, 0]));
        q.z *= Mathf.Sign(q.z * (m[1, 0] - m[0, 1]));
        return q;
    }

    void OnAnimatorIK()
    {
        Transform lefthand = avatarAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
        Transform righthand = avatarAnimator.GetBoneTransform(HumanBodyBones.RightHand);
        avatarAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        avatarAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

        avatarAnimator.SetIKPosition(AvatarIKGoal.LeftHand, lhand.transform.position);
        avatarAnimator.SetIKRotation(AvatarIKGoal.LeftHand, lhand.transform.rotation);

        avatarAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        avatarAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

        avatarAnimator.SetIKPosition(AvatarIKGoal.RightHand, rhand.transform.position);
        avatarAnimator.SetIKRotation(AvatarIKGoal.RightHand, rhand.transform.rotation);

    }

}
