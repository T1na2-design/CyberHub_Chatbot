namespace CybersecurityChatbot.Services
{
    public class ChatService
    {
        public string GetResponse(string query)
        {
            var lowerQuery = query.ToLower();

            if (lowerQuery.Contains("thank") || lowerQuery.Contains("thanks") || lowerQuery.Contains("thx") || lowerQuery.Contains("appreciate"))
            {
                return "😊 You're welcome! I'm happy I could help. If you have any more cybersecurity questions, feel free to ask — I'm always here!";
            }
            else if (lowerQuery.Contains("how are you") || lowerQuery.Contains("how do you do"))
            {
                return "🤖 I'm doing great! Thanks for asking. How can I help you with cybersecurity today?";
            }
            else if (lowerQuery.Contains("purpose") || lowerQuery.Contains("what do you do"))
            {
                return "💡 My purpose is to help you learn about cybersecurity and online safety. I can provide tips on passwords, phishing, safe browsing, and more!";
            }
            else if (lowerQuery.Contains("password"))
            {
                return "🔐 Password Safety Tips:\n" +
                       "  • Use strong, unique passwords for each account\n" +
                       "  • Include uppercase, lowercase, numbers, and symbols\n" +
                       "  • Use a password manager\n" +
                       "  • Enable two-factor authentication\n" +
                       "  • Never share your passwords with anyone";
            }
            else if (lowerQuery.Contains("phishing"))
            {
                return "📧 Phishing Awareness:\n" +
                       "  • Be suspicious of unexpected emails asking for personal info\n" +
                       "  • Check sender email addresses carefully\n" +
                       "  • Don't click on suspicious links\n" +
                       "  • Verify requests by contacting the company directly\n" +
                       "  • Look for spelling and grammar errors";
            }
            else if (lowerQuery.Contains("browsing") || lowerQuery.Contains("safe") && lowerQuery.Contains("web"))
            {
                return "🌐 Safe Browsing Tips:\n" +
                       "  • Use HTTPS websites (look for the padlock icon)\n" +
                       "  • Keep your browser updated\n" +
                       "  • Use a reputable antivirus software\n" +
                       "  • Be careful with public Wi-Fi\n" +
                       "  • Clear your browsing data regularly";
            }
            else if (lowerQuery.Contains("malware") || lowerQuery.Contains("virus") || lowerQuery.Contains("trojan") || lowerQuery.Contains("spyware"))
            {
                return "🦠 Malware Protection:\n" +
                       "  • Install and keep antivirus software up to date\n" +
                       "  • Never download files from untrusted sources\n" +
                       "  • Scan USB drives before opening files\n" +
                       "  • Avoid clicking pop-up ads or suspicious download buttons\n" +
                       "  • Regularly scan your system for threats";
            }
            else if (lowerQuery.Contains("social engineering") || lowerQuery.Contains("manipulation") || lowerQuery.Contains("impersonat"))
            {
                return "🎭 Social Engineering Awareness:\n" +
                       "  • Be wary of unsolicited phone calls claiming to be from IT or your bank\n" +
                       "  • Never give out personal info to unverified callers\n" +
                       "  • Question urgent requests that pressure you to act fast\n" +
                       "  • Verify identities through official channels before sharing data\n" +
                       "  • Remember: attackers exploit trust, fear, and urgency";
            }
            else if (lowerQuery.Contains("two-factor") || lowerQuery.Contains("2fa") || lowerQuery.Contains("mfa") || lowerQuery.Contains("multi-factor"))
            {
                return "🔑 Two-Factor Authentication (2FA):\n" +
                       "  • Always enable 2FA on accounts that support it\n" +
                       "  • Use authenticator apps instead of SMS when possible\n" +
                       "  • Keep backup codes in a secure location\n" +
                       "  • Never share your 2FA codes with anyone\n" +
                       "  • 2FA adds a critical second layer even if your password is stolen";
            }
            else if (lowerQuery.Contains("privacy") || lowerQuery.Contains("personal data") || lowerQuery.Contains("data protection"))
            {
                return "🛡️ Data Privacy Tips:\n" +
                       "  • Review app permissions and revoke unnecessary access\n" +
                       "  • Read privacy policies before signing up for services\n" +
                       "  • Use a VPN when accessing sensitive data on public networks\n" +
                       "  • Limit the personal information you share online\n" +
                       "  • Regularly check and manage your digital footprint";
            }
            else if (lowerQuery.Contains("ransomware"))
            {
                return "💰 Ransomware Prevention:\n" +
                       "  • Back up your data regularly to an offline or cloud location\n" +
                       "  • Do not open attachments from unknown senders\n" +
                       "  • Keep your operating system and software patched\n" +
                       "  • Use network segmentation to limit spread\n" +
                       "  • Never pay the ransom — it doesn't guarantee recovery";
            }
            else if (lowerQuery.Contains("wifi") || lowerQuery.Contains("wi-fi") || lowerQuery.Contains("wireless") || lowerQuery.Contains("public network"))
            {
                return "📶 Wi-Fi Security:\n" +
                       "  • Avoid accessing banking or sensitive accounts on public Wi-Fi\n" +
                       "  • Use a VPN to encrypt your traffic on open networks\n" +
                       "  • Disable auto-connect to open Wi-Fi networks\n" +
                       "  • Change your home router's default password and SSID\n" +
                       "  • Use WPA3 encryption on your home network if available";
            }
            else if (lowerQuery.Contains("social media") || lowerQuery.Contains("facebook") || lowerQuery.Contains("instagram") || lowerQuery.Contains("online profile"))
            {
                return "📱 Social Media Safety:\n" +
                       "  • Set your profiles to private and review who can see your posts\n" +
                       "  • Think before you share — personal details can be used against you\n" +
                       "  • Be cautious of friend requests from strangers\n" +
                       "  • Watch out for quizzes and apps that harvest your data\n" +
                       "  • Report and block suspicious accounts";
            }
            else if (lowerQuery.Contains("update") || lowerQuery.Contains("patch") || lowerQuery.Contains("software update"))
            {
                return "🔄 Software Updates & Patching:\n" +
                       "  • Enable automatic updates for your OS and applications\n" +
                       "  • Outdated software is one of the top attack vectors\n" +
                       "  • Prioritize security patches as soon as they are released\n" +
                       "  • Don't ignore update notifications — they fix known vulnerabilities\n" +
                       "  • Remove software you no longer use to reduce your attack surface";
            }
            else if (lowerQuery.Contains("identity theft") || lowerQuery.Contains("identity fraud") || lowerQuery.Contains("stolen identity"))
            {
                return "🪪 Identity Theft Prevention:\n" +
                       "  • Monitor your bank statements and credit reports regularly\n" +
                       "  • Shred documents that contain personal information before discarding\n" +
                       "  • Never share your ID number or SSN unless absolutely necessary\n" +
                       "  • Set up fraud alerts with your bank and credit bureau\n" +
                       "  • Act fast if you suspect your identity has been compromised";
            }
            else if (lowerQuery.Contains("email security") || lowerQuery.Contains("email safety") || lowerQuery.Contains("secure email"))
            {
                return "📨 Email Security Best Practices:\n" +
                       "  • Never open attachments from unknown or unexpected senders\n" +
                       "  • Use a strong, unique password for your email account\n" +
                       "  • Enable 2FA on all email accounts\n" +
                       "  • Be cautious of links — hover to preview the URL before clicking\n" +
                       "  • Use email encryption for sensitive communications";
            }
            else if (lowerQuery.Contains("backup") || lowerQuery.Contains("back up") || lowerQuery.Contains("data recovery"))
            {
                return "💾 Backup & Data Recovery:\n" +
                       "  • Follow the 3-2-1 rule: 3 copies, 2 different media, 1 offsite\n" +
                       "  • Automate your backups so you never forget\n" +
                       "  • Test your backups regularly to ensure they can be restored\n" +
                       "  • Keep at least one backup offline to protect against ransomware\n" +
                       "  • Use cloud backup services with encryption for critical data";
            }
            else if (lowerQuery.Contains("mobile") || lowerQuery.Contains("phone security") || lowerQuery.Contains("smartphone") || lowerQuery.Contains("device security"))
            {
                return "📲 Mobile Device Security:\n" +
                       "  • Use a strong PIN, password, or biometric lock on your device\n" +
                       "  • Only install apps from official app stores\n" +
                       "  • Review app permissions and deny unnecessary access\n" +
                       "  • Enable remote wipe in case your device is lost or stolen\n" +
                       "  • Keep your phone's OS and apps updated to the latest version";
            }
            else if (lowerQuery.Contains("iot") || lowerQuery.Contains("smart home") || lowerQuery.Contains("smart device"))
            {
                return "🏠 IoT & Smart Home Security:\n" +
                       "  • Change default passwords on all smart devices and routers\n" +
                       "  • Put smart devices on a separate guest Wi-Fi network\n" +
                       "  • Keep device firmware updated to patch vulnerabilities\n" +
                       "  • Disable features you don't use, like remote access or cameras\n" +
                       "  • Review privacy policies to understand what data is collected";
            }
            else
            {
                return "🤔 I'm not sure about that specific topic. Try asking about:\n" +
                       "  • Password safety\n" +
                       "  • Phishing awareness\n" +
                       "  • Safe browsing tips\n" +
                       "  • Malware protection\n" +
                       "  • Social engineering\n" +
                       "  • Two-factor authentication\n" +
                       "  • Data privacy\n" +
                       "  • Ransomware prevention\n" +
                       "  • Wi-Fi security\n" +
                       "  • Social media safety\n" +
                       "  • Software updates\n" +
                       "  • Identity theft\n" +
                       "  • Email security\n" +
                       "  • Backup & data recovery\n" +
                       "  • Mobile device security\n" +
                       "  • IoT & Smart Home security\n" +
                       "Or type 'help' to see all available topics.";
            }
        }
    }
}
